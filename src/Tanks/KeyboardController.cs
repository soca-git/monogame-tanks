using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Tanks
{
    internal static class KeyboardController
    {
        public static Vector2 WASDMove(KeyboardState keyState, float speed)
        {
            var displacement = Vector2.Zero;

            if (keyState.IsKeyDown(Keys.D))
            {
                displacement.X += speed;
            }

            if (keyState.IsKeyDown(Keys.A))
            {
                displacement.X -= speed;
            }

            if (keyState.IsKeyDown(Keys.W))
            {
                displacement.Y -= speed;
            }

            if (keyState.IsKeyDown(Keys.S))
            {
                displacement.Y += speed;
            }

            return displacement;
        }
    }
}
