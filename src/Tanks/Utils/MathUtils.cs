using Microsoft.Xna.Framework;
using System;

namespace Tanks.Utils
{
    internal static class MathUtils
    {
        public static float ToAngle(this Vector2 vector)
        {
            return (float)Math.Atan2(vector.Y, vector.X);
        }
    }
}
