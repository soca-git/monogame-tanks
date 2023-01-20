using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Tanks.Utils;

namespace Tanks.Sprites
{
    internal class Shell : Sprite
    {
        private const float _shellSpeed = 10;

        private readonly Vector2 _startPosition;
        private readonly float _range;

        private bool _exploded;

        public Shell(Texture2D texture, float startX, float startY, float scale, Color color, float range, float orientation)
            : base(texture, startX, startY, scale, color)
        {
            _startPosition = _position;
            _range = range;
            _orientation = orientation;
        }

        public override void Update(GameTime gameTime)
        {
            _position += _shellSpeed * _orientation.ToVector2();

            var trajectory = CurrentPosition() - _startPosition;

            if (trajectory.Length() > _range)
            {
                Explode();
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _position, null, _color, _orientation.ToRadians() + 90f.ToRadians(), _origin, _scale, SpriteEffects.None, 0);
        }

        public bool HasExploded()
        {
            return _exploded;
        }

        private void Explode()
        {
            _exploded = true;
        }
    }
}
