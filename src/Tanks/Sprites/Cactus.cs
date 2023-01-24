using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Tanks.Sprites
{
    internal class Cactus : Sprite, ICollidable
    {
        public Cactus(Texture2D texture, float startX, float startY, float scale, Color color) : base(texture, startX, startY, scale, color)
        {
        }

        public override void Update(GameTime gameTime)
        {
        }

        public float CollisionRadius()
        {
            return _width / 3;
        }

        public Vector2 CurrentPosition()
        {
            return _position;
        }

        public void Hit(GameTime gameTime)
        {
            _color = Color.DarkGray;
        }
    }
}
