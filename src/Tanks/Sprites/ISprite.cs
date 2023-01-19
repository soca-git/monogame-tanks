using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Tanks.Sprites
{
    internal interface ISprite
    {
        void Update(GameTime gameTime);

        void Draw(SpriteBatch spriteBatch);

        Vector2 CurrentPosition();

        Rectangle CurrentBox();
    }
}
