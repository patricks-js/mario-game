using Microsoft.Xna.Framework;

namespace LabFour.Entities;

public class Camera
{
    public Vector2 _position;

    public void Follow(Vector2 targetPosition, int viewportWidth)
    {
        _position.X = targetPosition.X - (viewportWidth / 2);
    }
}
