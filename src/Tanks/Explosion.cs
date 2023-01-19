using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Tanks
{
    internal class Explosion : Sprite
    {
        public Explosion(Texture2D texture, float startX, float startY, float scale)
            : base(texture, startX, startY, scale)
        {
            OffsetPosition();
        }

        public Explosion(Texture2D texture, float startX, float startY, float scale, Color color)
            : base(texture, startX, startY, scale, color)
        {
            OffsetPosition();
        }

        public override void Update(GameTime gameTime)
        {
            throw new System.NotImplementedException();
        }

        private void OffsetPosition()
        {
            _position += new Vector2(30, 0);
        }
    }
}
