using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Linq;

namespace Tanks.Sprites
{
    internal static class SpritesManager
    {
        private static List<ISprite> _sprites = new List<ISprite>();
        private static List<ICollidable> _collidables = new List<ICollidable>();

        public static void Add(ISprite sprite)
        {
            _sprites.Add(sprite);
        }

        public static void Update(GameTime gameTime)
        {
            HandleCollisions(gameTime);

            UpdateSprites(gameTime);
        }

        private static void HandleCollisions(GameTime gameTime)
        {
            foreach(ICollidable a in _collidables)
            {
                foreach (ICollidable b in _collidables)
                {
                    if (a != b && IsColliding(a, b))
                    {
                        a.Hit(gameTime);
                        b.Hit(gameTime);
                    }
                }
            }
        }

        private static bool IsColliding(ICollidable a, ICollidable b)
        {
            float radius = a.CollisionRadius() + b.CollisionRadius();
            return Vector2.DistanceSquared(a.CurrentPosition(), b.CurrentPosition()) < radius * radius;
        }

        private static void UpdateSprites(GameTime gameTime)
        {
            foreach (ISprite sprite in _sprites)
            {
                sprite.Update(gameTime);
            }

            _sprites = _sprites.Where(sprite => !sprite.IsExpired()).ToList();
            _collidables = _sprites.Where(sprite => sprite is ICollidable).Cast<ICollidable>().ToList();
        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            foreach (ISprite sprite in _sprites)
            {
                sprite.Draw(spriteBatch);
            }
        }
    }
}
