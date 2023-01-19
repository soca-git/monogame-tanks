using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Tanks.Sprites
{
    internal class Tank : Sprite
    {
        private const float _speed = 2;

        public Tank(Texture2D texture, float startX, float startY, float scale)
            : base(texture, startX, startY, scale)
        {
        }

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
            _position += KeyboardController.WASDMove(keyState, _speed);
        }
    }
}
