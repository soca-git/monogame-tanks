using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using System;
using Tanks.ContentManagers;

namespace Tanks.Sprites
{
    internal class Explosion : Sprite
    {
        private readonly SoundEffect soundEffect = SoundEffectsManager.Get("explosion");
        
        private TimeSpan _explosionStartTime;
        private bool _exploded;

        public Explosion(Texture2D texture, float startX, float startY, float scale)
            : base(texture, startX, startY, scale)
        {
            OffsetPosition();
        }

        public Explosion(Texture2D texture, float startX, float startY, float scale, Color color)
            : base(texture, startX, startY, scale, color)
        {
            OffsetPosition();
        }

        public override void Update(GameTime gameTime)
        {
            if (gameTime.TotalGameTime - _explosionStartTime > soundEffect.Duration)
            {
                _exploded = true;
            }
        }

        public void Explode(GameTime gameTime)
        {
            _explosionStartTime = gameTime.TotalGameTime;
            soundEffect.Play();
        }

        public bool HasExploded()
        {
            return _exploded;
        }

        private void OffsetPosition()
        {
            _position += new Vector2(30, 0);
        }
    }
}
