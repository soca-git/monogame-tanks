using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Tanks.Controllers;

namespace Tanks.Sprites
{
    internal class Tank : Sprite
    {
        private const float _speed = 2;
        private const float _traversalSpeed = 0.02f;

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
            _position += KeyboardController.WSMove(keyState, _speed);
        }
    }
}
