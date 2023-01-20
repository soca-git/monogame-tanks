using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Tanks.Sprites
{
    internal class Marker : Sprite
    {
        public Marker(Texture2D texture, float startX, float startY, float scale, Color color)
            : base(texture, startX, startY, scale, color)
        {
        }

        public override void Update(GameTime gameTime)
        {
            throw new System.NotImplementedException();
        }
    }
}
