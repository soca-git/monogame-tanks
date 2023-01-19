using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;

namespace Tanks.ContentManagers
{
    internal static class SongsManager
    {
        private static readonly Dictionary<string, Song> _songs = new Dictionary<string, Song>();

        public static void Add(string name, string assetPath, ContentManager content)
        {
            _songs.TryAdd(name, content.Load<Song>(assetPath));
        }

        public static Song Get(string name)
        {
            if (_songs.ContainsKey(name))
            {
                return _songs[name];
            }

            throw new Exception($"{name} does not exist in the {nameof(SongsManager)}.");
        }
    }
}
