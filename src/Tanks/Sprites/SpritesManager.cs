using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Tanks.Sprites
{
    internal static class SpritesManager
    {
        private static readonly LinkedList<Shell> _firedRounds = new LinkedList<Shell>();

        public static void Add(Shell shell)
        {
            _firedRounds.AddFirst(shell);
        }

        public static void Update(GameTime gameTime)
        {
            UpdateFiredRounds(gameTime);
        }

        private static void UpdateFiredRounds(GameTime gameTime)
        {
            if (_firedRounds.Count > 0)
            {
                foreach (ISprite round in _firedRounds)
                {
                    round.Update(gameTime);
                }

                if (_firedRounds.Last.Value.HasExploded())
                {
                    _firedRounds.RemoveLast();
                }
            }
        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            DrawFiredRounds(spriteBatch);
        }

        private static void DrawFiredRounds(SpriteBatch spriteBatch)
        {
            if (_firedRounds.Count > 0)
            {
                foreach (ISprite round in _firedRounds)
                {
                    round.Draw(spriteBatch);
                }
            }
        }
    }
}
