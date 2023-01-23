using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Tanks.Sprites
{
    internal class Barrel : Sprite, ICollidable
    {
        public Barrel(Texture2D texture, float startX, float startY, float scale, Color color)
            : base(texture, startX, startY, scale, color)
        {
        }

        public override void Update(GameTime gameTime)
        {
            throw new System.NotImplementedException();
        }

        public float CollisionRadius()
        {
            return _width / 3;
        }
    }
}
