using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LabFour.Interfaces;

public interface IEntities
{
    void Update(GameTime gameTime);
    void Draw(SpriteBatch spriteBatch);
}
