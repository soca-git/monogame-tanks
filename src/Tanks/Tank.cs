using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Tanks
{
    internal class Tank
    {
        private readonly Texture2D _texture;
        private readonly Color _color = Color.White;

        private Rectangle _box;
        private Vector2 _position = new Vector2(0, 0);

        public Tank(int width, int height, Texture2D texture)
        {
            _texture = texture;
            _box = new Rectangle((int)_position.X, (int)_position.Y, width, height);
        }

        public Tank(int width, int height, Texture2D texture, Color color)
        {
            _texture = texture;
            _box = new Rectangle((int)_position.X, (int)_position.Y, width, height);
            _color = color;
        }

        public Rectangle Box => _box;

        public Texture2D Texture => _texture;

        public Color Color => _color;

        public Vector2 Position
        {
            get { return _position; }
            set { _position = value; _box.X = (int)value.X; _box.Y = (int)value.Y; }
        }
    }
}
