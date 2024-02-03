using LabFour.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LabFour.Entities;

public class Map : IEntities
{
    private readonly Texture2D texture;
    private Vector2 cameraPosition;

    public Map(Texture2D texture)
    {
        this.texture = texture;
        cameraPosition = Vector2.Zero;
    }

    public void Update(Camera camera)
    {
        cameraPosition.X = camera._position.X;
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(texture, new Vector2(-cameraPosition.X, 0), Color.White);
    }

    public void Update(GameTime gameTime) { }
}
