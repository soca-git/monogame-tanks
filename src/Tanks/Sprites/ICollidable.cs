using Microsoft.Xna.Framework;

namespace Tanks.Sprites
{
    internal interface ICollidable
    {
        float CollisionRadius();

        Vector2 CurrentPosition();

        void Hit(GameTime gameTime);
    }
}
