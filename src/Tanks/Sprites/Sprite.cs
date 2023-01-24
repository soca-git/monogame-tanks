using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Tanks.Utils;

namespace Tanks.Sprites
{
    internal abstract class Sprite : ISprite
    {
        protected readonly Texture2D _texture;
        protected readonly Color _color = Color.White;
        protected readonly float _width;
        protected readonly float _height;
        protected readonly float _scale;
        protected readonly Vector2 _origin;

        protected Vector2 _position;
        protected float _orientation;
        protected bool _expired;
        
        public Vector2 Origin => _origin;

        public Sprite(Texture2D texture, float startX, float startY, float scale, Color color)
        {
            _texture = texture;
            _width = texture.Width * scale;
            _height = texture.Height * scale;
            _scale = scale;
            _color = color;

            _position = new Vector2(startX, startY);
            _origin = new Vector2(texture.Width / 2f, texture.Height / 2f); // Use original width & height!
        }

        public Rectangle CurrentBox() => new Rectangle((int)(_position.X - _width / 2), (int)(_position.Y - _height / 2), (int)_width, (int)_height);

        public Vector2 CurrentPosition() => _position;

        public float CurrentOrientation() => _orientation;

        public virtual bool IsExpired() => _expired;

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _position, null, _color, _orientation.ToRadians(), _origin, _scale, SpriteEffects.None, 0);
        }

        public abstract void Update(GameTime gameTime);
    }
}
