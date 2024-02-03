using LabFour.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace LabFour.Entities;

public class Mario : IEntities
{
    private const int FPS = 20;
    private readonly Texture2D _texture;
    public Vector2 _position;

    public Mario(Texture2D texture, Vector2 position)
    {
        _texture = texture;
        _position = position;
    }

    public void Update(GameTime gameTime)
    {
        KeyboardState keyboardState = Keyboard.GetState();
        if (keyboardState.IsKeyDown(Keys.Left))
            _position.X -= FPS;

        if (keyboardState.IsKeyDown(Keys.Right))
            _position.X += FPS;
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(_texture, _position, Color.White);
    }
}
