using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Tanks.Sprites
{
    internal static class SpritesManager
    {
        private static readonly LinkedList<Shell> _shells = new LinkedList<Shell>();
        private static readonly LinkedList<Barrel> _barrels = new LinkedList<Barrel>();
        private static readonly LinkedList<Cactus> _cacti = new LinkedList<Cactus>();

        public static void Add(Shell shell)
        {
            _shells.AddFirst(shell);
        }

        public static void Add(Barrel barrel)
        {
            _barrels.AddFirst(barrel);
        }

        public static void Add(Cactus cactus)
        {
            _cacti.AddFirst(cactus);
        }

        public static void Update(GameTime gameTime)
        {
            HandleCollisions(gameTime);

            UpdateFiredRounds(gameTime);
        }

        private static void HandleCollisions(GameTime gameTime)
        {
            foreach(Shell shell in _shells)
            {
                foreach(Barrel barrel in _barrels)
                {
                    if (IsColliding(shell, barrel))
                    {
                        shell.Explode(gameTime);
                    }
                }
            }
        }

        private static bool IsColliding(ICollidable a, ICollidable b)
        {
            float radius = a.CollisionRadius() + b.CollisionRadius();
            return Vector2.DistanceSquared(a.CurrentPosition(), b.CurrentPosition()) < radius * radius;
        }

        private static void UpdateFiredRounds(GameTime gameTime)
        {
            if (_shells.Count > 0)
            {
                foreach (ISprite round in _shells)
                {
                    round.Update(gameTime);
                }

                if (_shells.Last.Value.HasExploded())
                {
                    _shells.RemoveLast();
                }
            }
        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            DrawFiredRounds(spriteBatch);
            DrawBarrels(spriteBatch);
            DrawCacti(spriteBatch);
        }

        private static void DrawFiredRounds(SpriteBatch spriteBatch)
        {
            if (_shells.Count > 0)
            {
                foreach (ISprite round in _shells)
                {
                    round.Draw(spriteBatch);
                }
            }
        }

        private static void DrawBarrels(SpriteBatch spriteBatch)
        {
            if (_barrels.Count > 0)
            {
                foreach (ISprite barrel in _barrels)
                {
                    barrel.Draw(spriteBatch);
                }
            }
        }

        private static void DrawCacti(SpriteBatch spriteBatch)
        {
            if (_cacti.Count > 0)
            {
                foreach (ISprite cactus in _cacti)
                {
                    cactus.Draw(spriteBatch);
                }
            }
        }
    }
}
