using System;
using LabFour.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace LabFour.Screens;

public class StartScreen : GameScreenBase
{
    private Texture2D _logoTexture;
    private BlinkingText _pressToStart;
    private Song _song;

    public StartScreen(SuperMario game)
        : base(game) { }

    public override void LoadContent()
    {
        _song = SuperMarioGame.Content.Load<Song>("sounds/supermario_music");

        _logoTexture = SuperMarioGame.Content.Load<Texture2D>("sprites/supermario");

        SpriteFont font = SuperMarioGame.Content.Load<SpriteFont>("Fonts/Press Start 2P");

        _pressToStart = new BlinkingText(font, "<Press Space to start>", TimeSpan.FromSeconds(0.5));

        MediaPlayer.Volume -= 0.95f;
        MediaPlayer.Play(_song);
        MediaPlayer.IsRepeating = true;
    }

    public override void Update(GameTime gameTime)
    {
        KeyboardState keyboard = Keyboard.GetState();

        _pressToStart.Update(gameTime);

        if (keyboard.IsKeyDown(Keys.Space))
        {
            MediaPlayer.Stop();
            SuperMarioGame.ChangeScreen(new GameScreen(SuperMarioGame));
        }
    }

    public override void Draw(SpriteBatch spriteBatch)
    {
        Vector2 screenDimensions = new(SuperMarioGame.screenX, SuperMarioGame.screenY + 200);

        Vector2 logoCenter =
            new(
                (SuperMarioGame.screenX - _logoTexture.Width) / 2,
                (SuperMarioGame.screenY - 300) / 2
            );

        spriteBatch.Begin();

        spriteBatch.Draw(_logoTexture, logoCenter, Color.White);
        _pressToStart.Draw(spriteBatch, screenDimensions, Color.White);

        spriteBatch.End();
    }
}
