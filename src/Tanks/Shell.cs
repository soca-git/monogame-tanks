using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Tanks
{
    internal class Shell : Sprite
    {
        public Shell(Texture2D texture, float startX, float startY, float scale)
            : base(texture, startX, startY, scale)
        {
            _position -= new Vector2(texture.Width * scale / 2, texture.Height * scale / 2);
        }

        public Shell(Texture2D texture, float startX, float startY, float scale, Color color)
            : base(texture, startX, startY, scale, color)
        {
            _position -= new Vector2(texture.Width * scale / 2, texture.Height * scale / 2);
        }

        public override void Update(GameTime gameTime)
        {
            _position.Y += 15;
        }
    }
}
