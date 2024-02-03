using LabFour.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LabFour.Screens;

public class GameScreen : GameScreenBase
{
    Mario player;
    Map background;
    Camera camera;

    public GameScreen(SuperMario game)
        : base(game) { }

    public override void LoadContent()
    {
        Texture2D playerTexture = SuperMarioGame.Content.Load<Texture2D>("sprites/block");
        Texture2D backgroundTexture = SuperMarioGame.Content.Load<Texture2D>("sprites/background");

        player = new Mario(playerTexture, new Vector2(50, 50));
        background = new Map(backgroundTexture);
        camera = new Camera();
    }

    public override void Update(GameTime gameTime)
    {
        player.Update(gameTime);
        background.Update(camera);

        camera.Follow(player._position, SuperMarioGame.GraphicsDevice.Viewport.Width);
    }

    public override void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Begin();

        background.Draw(spriteBatch);
        player.Draw(spriteBatch);

        spriteBatch.End();
    }
}
