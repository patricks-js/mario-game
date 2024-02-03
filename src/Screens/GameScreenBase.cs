using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LabFour.Screens;

public abstract class GameScreenBase
{
    protected SuperMario SuperMarioGame;

    public GameScreenBase(SuperMario game)
    {
        SuperMarioGame = game;
    }

    public abstract void LoadContent();
    public abstract void Update(GameTime gameTime);
    public abstract void Draw(SpriteBatch spriteBatch);
}
