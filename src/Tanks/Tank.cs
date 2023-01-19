using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Tanks
{
    internal class Tank
    {
        private readonly Color _color = Color.White;
        private readonly Texture2D _texture;
        private readonly float _width;
        private readonly float _height;
        private readonly Rectangle _sourceRectangle;

        private Vector2 _position;

        public Tank(Texture2D texture, float startX, float startY, float scale)
        {
            _texture = texture;
            _width = texture.Width * scale;
            _height = texture.Height * scale;
            _sourceRectangle = new Rectangle(0, 0, texture.Width, texture.Height);

            _position = new Vector2(startX, startY);
        }

        public Vector2 Position => _position;

        public Rectangle Box => new Rectangle((int)_position.X, (int)_position.Y, (int)_width, (int)_height);

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(
                _texture,
                Box,
                _sourceRectangle,
                _color);
        }

        public void Move(Vector2 movement)
        {
            _position += movement;
        }
    }
}
