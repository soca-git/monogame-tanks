using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace Tanks.ContentManagers
{
    internal static class TexturesManager
    {
        private static readonly Dictionary<string, Texture2D> _textures = new Dictionary<string, Texture2D>();

        public static void Add(string name, string assetPath, ContentManager content)
        {
            _textures.TryAdd(name, content.Load<Texture2D>(assetPath));
        }

        public static Texture2D Get(string name)
        {
            if (_textures.ContainsKey(name))
            {
                return _textures[name];
            }

            throw new Exception($"{name} does not exist in the {nameof(TexturesManager)}.");
        }
    }
}
