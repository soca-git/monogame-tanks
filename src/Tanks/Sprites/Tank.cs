using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using Tanks.ContentManagers;
using Tanks.Controllers;
using Tanks.Utils;

namespace Tanks.Sprites
{
    internal class Tank : Sprite
    {
        private const float _speed = 2;
        private const float _traversalSpeed = 1f;
        private const float _reloadTime = 2;

        private readonly float _orientationOffset = -90f.ToRadians();
        private TimeSpan _fireTime;
        private int _firedRounds;

        #region Events
        //public event EventHandler<FiredRoundEventArgs> OnFireRound; // using the standard event delegate EventHandler

        public event EventHandler<FiredRoundEventArgs> OnFireRound; // using the standard event delegate EventHandler with optional custom <TEventArgs>

        //public event FiredRoundDelegate OnFireRound; // using the delegate defined below
        //public delegate void FiredRoundDelegate(int firedRounds);

        //public event Action OnFireRound; // using the standard Action delegate
        //public event Action<int, bool> OnFireRound; // using the standard Action delegate which accepts two parameters, one int and one bool
        #endregion

        public Tank(Texture2D texture, float startX, float startY, float scale, Color color)
            : base(texture, startX, startY, scale, color)
        {
        }

        public override void Update(GameTime gameTime)
        {
            var keyState = Keyboard.GetState();

            UpdatePosition(keyState);
            FireRound(keyState, gameTime);
        }

        private void UpdatePosition(KeyboardState keyState)
        {
            _orientation += KeyboardController.ADTurn(keyState, _traversalSpeed);
            _position += KeyboardController.WSMove(keyState, _speed) * _orientation.ToVector2();
        }

        private void FireRound(KeyboardState keyState, GameTime gameTime)
        {
            if (keyState.IsKeyDown(Keys.Space) && gameTime.TotalGameTime.TotalSeconds > (_fireTime.TotalSeconds + _reloadTime))
            {
                _fireTime = gameTime.TotalGameTime;

                var orientation = _orientation.ToVector2();
                var shellPosition = _position + (5 + _height / 2) * orientation;

                SpritesManager.Add(new Shell(TexturesManager.Get("shell"), shellPosition.X, shellPosition.Y, 0.5f, Color.White, 400, _orientation));

                _firedRounds++;
                OnFireRound?.Invoke(this, new FiredRoundEventArgs { FiredRounds = _firedRounds });
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _position, null, _color, _orientation.ToRadians() + _orientationOffset, _origin, _scale, SpriteEffects.None, 0);
        }
    }

    public class FiredRoundEventArgs : EventArgs
    {
        public int FiredRounds { get; set; }
    }
}
