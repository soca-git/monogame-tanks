using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Tanks.Controllers
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

        public static float WSMove(KeyboardState keyState, float speed)
        {
            if (keyState.IsKeyDown(Keys.W))
            {
                return speed;
            }

            if (keyState.IsKeyDown(Keys.S))
            {
                return -1 * speed;
            }

            return 0;
        }

        public static float ADTurn(KeyboardState keyState, float traversalSpeed)
        {
            if (keyState.IsKeyDown(Keys.D))
            {
                return traversalSpeed;
            }

            if (keyState.IsKeyDown(Keys.A))
            {
                return -1 * traversalSpeed;
            }

            return 0;
        }
    }
}
