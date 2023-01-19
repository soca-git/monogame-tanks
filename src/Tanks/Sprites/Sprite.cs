using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Tanks.Sprites
{
    internal abstract class Sprite : ISprite
    {
        private readonly Texture2D _texture;
        private readonly Color _color = Color.White;
        private readonly float _width;
        private readonly float _height;
        private readonly Rectangle _sourceRectangle;

        protected Vector2 _position;

        public Sprite(Texture2D texture, float startX, float startY, float scale)
        {
            _texture = texture;
            _width = texture.Width * scale;
            _height = texture.Height * scale;
            _sourceRectangle = new Rectangle(0, 0, texture.Width, texture.Height);

            _position = new Vector2(startX - texture.Width * scale / 2, startY - texture.Height * scale / 2);
        }

        public Sprite(Texture2D texture, float startX, float startY, float scale, Color color)
        {
            _texture = texture;
            _color = color;
            _width = texture.Width * scale;
            _height = texture.Height * scale;
            _sourceRectangle = new Rectangle(0, 0, texture.Width, texture.Height);

            _position = new Vector2(startX - texture.Width * scale / 2, startY - texture.Height * scale / 2);
        }

        public Rectangle CurrentBox() => new Rectangle((int)_position.X, (int)_position.Y, (int)_width, (int)_height);

        public Vector2 CurrentPosition() => _position;

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, CurrentBox(), _sourceRectangle, _color);
        }

        public abstract void Update(GameTime gameTime);
    }
}
