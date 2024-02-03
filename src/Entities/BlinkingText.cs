using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LabFour.Entities;

public class BlinkingText
{
    private readonly SpriteFont font;
    private readonly string text;
    private bool isVisible = true;
    private readonly TimeSpan blinkInterval;
    private TimeSpan elapsedTime;

    public BlinkingText(SpriteFont font, string text, TimeSpan blinkInterval)
    {
        this.font = font;
        this.text = text;
        this.blinkInterval = blinkInterval;
    }

    public void Update(GameTime gameTime)
    {
        elapsedTime += gameTime.ElapsedGameTime;

        if (elapsedTime >= blinkInterval)
        {
            isVisible = !isVisible;
            elapsedTime = TimeSpan.Zero;
        }
    }

    public void Draw(SpriteBatch spriteBatch, Vector2 dimensions, Color color)
    {
        var fontSize = font.MeasureString(text);

        var position = new Vector2(
            (dimensions.X - fontSize.X) / 2,
            (dimensions.Y - fontSize.Y) / 2
        );

        if (isVisible)
        {
            spriteBatch.DrawString(font, text, position, color);
        }
    }
}
