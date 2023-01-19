using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Tanks
{
    internal class Tank
    {
        private readonly Texture2D _texture;
        private readonly Rectangle _rectangle;
        private readonly Color _color = Color.White;
        private int x = 50;
        private int y = 50;

        public Tank(int width, int height, Texture2D texture)
        {
            _texture = texture;
            _rectangle = new Rectangle(x, y, width, height);
        }

        public Tank(int width, int height, Texture2D texture, Color color)
        {
            _texture = texture;
            _rectangle = new Rectangle(x, y, width, height);
            _color = color;
        }

        public Rectangle Box => _rectangle;

        public Texture2D Texture => _texture;

        public Color Color => _color;
    }
}
