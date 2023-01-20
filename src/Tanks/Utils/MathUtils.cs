using Microsoft.Xna.Framework;
using System;

namespace Tanks.Utils
{
    internal static class MathUtils
    {
        public static float ToRadians(this float degrees)
        {
            return (float)Math.PI / 180 * degrees;
        }

        public static float ToAngle(this Vector2 vector)
        {
            return (float)Math.Atan2(vector.Y, vector.X);
        }

        public static Vector2 ToVector2(this float degrees)
        {
            var radians = degrees.ToRadians();
            return new Vector2((float)Math.Cos(radians), (float)Math.Sin(radians));
        }
    }
}
