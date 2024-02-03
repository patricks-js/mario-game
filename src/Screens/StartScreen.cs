using System;
using LabFour.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace LabFour.Screens;

public class StartScreen : GameScreenBase
{
    private Texture2D _superMarioLogoTexture;
    private Vector2 _superMarioLogoVector;
    private BlinkingText _tapToStart;
    private Song _song;

    public StartScreen(SuperMario game)
        : base(game)
    {
        _superMarioLogoVector = new Vector2(400, 200);
    }

    public override void LoadContent()
    {
        _song = SuperMarioGame.Content.Load<Song>("sounds/supermario_music");

        _superMarioLogoTexture = SuperMarioGame.Content.Load<Texture2D>("sprites/supermario");

        SpriteFont font = SuperMarioGame.Content.Load<SpriteFont>("Fonts/Press Start 2P");

        _tapToStart = new BlinkingText(font, "Press Start", TimeSpan.FromSeconds(0.5));

        MediaPlayer.Volume -= 0.95f;
        MediaPlayer.Play(_song);
        MediaPlayer.IsRepeating = true;
    }

    public override void Update(GameTime gameTime)
    {
        KeyboardState keyboard = Keyboard.GetState();

        _tapToStart.Update(gameTime);

        if (keyboard.IsKeyDown(Keys.Space))
        {
            MediaPlayer.Stop();
            SuperMarioGame.ChangeScreen(new GameScreen(SuperMarioGame));
        }
    }

    public override void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Begin();

        spriteBatch.Draw(_superMarioLogoTexture, _superMarioLogoVector, Color.White);

        _tapToStart.Draw(spriteBatch, new Vector2(100, 100), Color.White);

        spriteBatch.End();
    }
}
