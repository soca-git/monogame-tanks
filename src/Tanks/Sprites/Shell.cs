using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Tanks.ContentManagers;
using Tanks.Utils;

namespace Tanks.Sprites
{
    internal class Shell : Sprite, ICollidable
    {
        private const float _shellSpeed = 15;

        private readonly Vector2 _startPosition;
        private readonly float _range;

        private Explosion _explosion;

        public Shell(Texture2D texture, float startX, float startY, float scale, Color color, float range, float orientation)
            : base(texture, startX, startY, scale, color)
        {
            _startPosition = _position;
            _range = range;
            _orientation = orientation;
        }

        public override void Update(GameTime gameTime)
        {
            UpdatePosition();
            ExplodeIfMaximumRange(gameTime);
            UpdateExplosion(gameTime);
        }

        private void UpdatePosition()
        {
            if (_explosion == null)
            {
                _position += _shellSpeed * _orientation.ToVector2();
            }
        }

        private void ExplodeIfMaximumRange(GameTime gameTime)
        {
            var trajectory = _position - _startPosition;

            if (trajectory.Length() > _range)
            {
                Explode(gameTime);
            }
        }

        private void Explode(GameTime gameTime)
        {
            if (_explosion == null)
            {
                _explosion = new Explosion(TexturesManager.Get("explosion"), _position.X, _position.Y, 0.5f, Color.White);
                _explosion.Explode(gameTime);
            }
        }

        private void UpdateExplosion(GameTime gameTime)
        {
            if (_explosion != null)
            {
                _explosion.Update(gameTime);
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _position, null, _color, _orientation.ToRadians() + 90f.ToRadians(), _origin, _scale, SpriteEffects.None, 0);

            if (_explosion != null)
            {
                _explosion.Draw(spriteBatch);
            }
        }

        public override bool IsExpired()
        {
            return _explosion != null && _explosion.IsExpired();
        }

        public float CollisionRadius()
        {
            return 1;
        }

        public Vector2 CurrentPosition()
        {
            return _position;
        }

        public void Hit(GameTime gameTime)
        {
            Explode(gameTime);
        }
    }
}
