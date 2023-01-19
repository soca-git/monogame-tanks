using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace Tanks.ContentManagers
{
    internal static class FontsManager
    {
        private static readonly Dictionary<string, SpriteFont> _fonts = new Dictionary<string, SpriteFont>();

        public static void Add(string name, string assetPath, ContentManager content)
        {
            _fonts.TryAdd(name, content.Load<SpriteFont>(assetPath));
        }

        public static SpriteFont Get(string name)
        {
            if (_fonts.ContainsKey(name))
            {
                return _fonts[name];
            }

            throw new Exception($"{name} does not exist in the {nameof(FontsManager)}.");
        }
    }
}
