using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Tanks.Controllers;
using Tanks.Utils;

namespace Tanks.Sprites
{
    internal class Tank : Sprite
    {
        private const float _speed = 2;
        private const float _traversalSpeed = 1f;
        private readonly float _orientationOffset = -90f.ToRadians();

        public Tank(Texture2D texture, float startX, float startY, float scale, Color color)
            : base(texture, startX, startY, scale, color)
        {
        }

        public override void Update(GameTime gameTime)
        {
            throw new System.NotImplementedException();
        }

        public void UpdatePosition(KeyboardState keyState)
        {
            _orientation += KeyboardController.ADTurn(keyState, _traversalSpeed);
            _position += KeyboardController.WSMove(keyState, _speed) * _orientation.ToVector2();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _position, null, _color, _orientation.ToRadians() + _orientationOffset, _origin, _scale, SpriteEffects.None, 0);
        }
    }
}
