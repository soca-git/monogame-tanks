using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;

namespace Tanks.ContentManagers
{
    internal static class SoundEffectsManager
    {
        private static readonly Dictionary<string, SoundEffect> _soundEffects = new Dictionary<string, SoundEffect>();

        public static void Add(string name, string assetPath, ContentManager content)
        {
            _soundEffects.TryAdd(name, content.Load<SoundEffect>(assetPath));
        }

        public static SoundEffect Get(string name)
        {
            if (_soundEffects.ContainsKey(name))
            {
                return _soundEffects[name];
            }

            throw new Exception($"{name} does not exist in the {nameof(SoundEffectsManager)}.");
        }
    }
}
