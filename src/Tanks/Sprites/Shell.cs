using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Tanks.Sprites
{
    internal class Shell : Sprite
    {
        private readonly Vector2 _startPosition;
        private readonly float _range;

        private bool _exploded;

        public Shell(Texture2D texture, float startX, float startY, float scale, Color color, float range)
            : base(texture, startX, startY, scale, color)
        {
            _startPosition = _position;
            _range = range;
        }

        public override void Update(GameTime gameTime)
        {
            _position.Y += 15;

            var trajectory = CurrentPosition() - _startPosition;

            if (trajectory.Length() > _range)
            {
                Explode();
            }
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
