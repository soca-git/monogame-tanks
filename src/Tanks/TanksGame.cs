﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Tanks
{
    public class TanksGame : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private const int _screenWidth = 800;
        private const int _screenHeight = 600;
        private readonly Rectangle _backgroundSize = new Rectangle(0, 0, _screenWidth, _screenHeight);

        private readonly Dictionary<string, SpriteFont> _fonts = new Dictionary<string, SpriteFont>();
        private readonly Dictionary<string, Texture2D> _textures = new Dictionary<string, Texture2D>();
        private readonly Dictionary<string, SoundEffect> _sounds = new Dictionary<string, SoundEffect>();

        Tank Tank;
        Shell Shell;
        Explosion Explosion;

        public TanksGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferWidth = _screenWidth;
            _graphics.PreferredBackBufferHeight = _screenHeight;

            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            _fonts.Add("default", Content.Load<SpriteFont>("defaultFont"));

            _textures.Add("background", Content.Load<Texture2D>("background"));
            _textures.Add("tank", Content.Load<Texture2D>("Pz.Kpfw.IV-G_preview"));
            _textures.Add("shell", Content.Load<Texture2D>("Light_Shell"));
            _textures.Add("explosion", Content.Load<Texture2D>("Explosion_C"));

            _sounds.Add("explosion", Content.Load<SoundEffect>("explosion04"));
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            if (Tank == null)
            {
                Tank = new Tank(_textures["tank"], 0, 0, 0.5f);
            }

            var keyState = Keyboard.GetState();

            Tank.UpdatePosition(keyState);

            if (keyState.IsKeyDown(Keys.Space) && Shell == null)
            {
                Shell = new Shell(_textures["shell"], Tank.CurrentBox().Center.X, Tank.CurrentBox().Bottom, 0.5f, 400);
            }

            if (Shell != null)
            {
                Shell.Update(gameTime);

                if (Shell.HasExploded())
                {
                    Explosion = new Explosion(_textures["explosion"], Shell.CurrentPosition().X, Shell.CurrentPosition().Y, 0.5f);
                    _sounds["explosion"].Play();
                    Shell = null;
                }
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here. The order of drawing matters!
            _spriteBatch.Begin();

            // Draw
            _spriteBatch.Draw(_textures["background"], _backgroundSize, Color.White);

            if (Tank != null)
            {
                Tank.Draw(_spriteBatch);
            }

            if (Shell != null)
            {
                Shell.Draw(_spriteBatch);
            }

            if (Explosion != null)
            {
                Explosion.Draw(_spriteBatch);
            }

            _spriteBatch.DrawString(_fonts["default"], "Tanks very much!", new Vector2(5, _screenHeight - 20), Color.Aquamarine);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
