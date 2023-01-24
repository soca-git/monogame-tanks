using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Diagnostics;
using Tanks.ContentManagers;
using Tanks.Sprites;

namespace Tanks
{
    public class TanksGame : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private const int _screenWidth = 1000;
        private const int _screenHeight = 800;
        private readonly Rectangle _backgroundSize = new Rectangle(0, 0, _screenWidth, _screenHeight);

        Tank Tank;
        private int _roundsFired;

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
            FontsManager.Add("default", "defaultFont", Content);

            TexturesManager.Add("background", "background", Content);
            TexturesManager.Add("tank", "Pz.Kpfw.IV-G_preview", Content);
            TexturesManager.Add("shell", "Light_Shell", Content);
            TexturesManager.Add("explosion", "Explosion_C", Content);
            TexturesManager.Add("marker", "Markup_01", Content);
            TexturesManager.Add("barrel", "Barell_01", Content);
            TexturesManager.Add("cactus", "Cactus_03", Content);

            SoundEffectsManager.Add("explosion", "explosion04", Content);

            SongsManager.Add("background", "Brothers In Arms March (128 kbps)", Content);

            MediaPlayer.Play(SongsManager.Get("background"));
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Volume *= 0.1f;

            Tank = new Tank(TexturesManager.Get("tank"), 100, 100, 0.5f, Color.Wheat);

            SpritesManager.Add(new Barrel(TexturesManager.Get("barrel"), 400, 400, 0.3f, Color.MediumVioletRed));
            SpritesManager.Add(new Barrel(TexturesManager.Get("barrel"), 800, 200, 0.3f, Color.GreenYellow));
            SpritesManager.Add(new Barrel(TexturesManager.Get("barrel"), 100, 600, 0.3f, Color.BlueViolet));
            SpritesManager.Add(new Barrel(TexturesManager.Get("barrel"), 800, 700, 0.3f, Color.White));

            SpritesManager.Add(new Cactus(TexturesManager.Get("cactus"), 100, 300, 0.3f, Color.White));
            SpritesManager.Add(new Cactus(TexturesManager.Get("cactus"), 300, 700, 0.3f, Color.White));
            SpritesManager.Add(new Cactus(TexturesManager.Get("cactus"), 600, 600, 0.3f, Color.White));

            Tank.OnFireRound += UpdateRoundsFired;
        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }

            // TODO: Add your update logic here
            Tank.Update(gameTime);
            SpritesManager.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here. The order of drawing matters!
            _spriteBatch.Begin();

            // Draw
            _spriteBatch.Draw(TexturesManager.Get("background"), _backgroundSize, Color.White);

            SpritesManager.Draw(_spriteBatch);
            Tank.Draw(_spriteBatch);

            _spriteBatch.DrawString(FontsManager.Get("default"), "Tanks very much!", new Vector2(_screenWidth - 125, _screenHeight - 20), Color.Aquamarine);
            _spriteBatch.DrawString(FontsManager.Get("default"), $"Rounds fired: {_roundsFired}", new Vector2(5, _screenHeight - 20), Color.Aquamarine);

            _spriteBatch.End();

            base.Draw(gameTime);
        }

        private void UpdateRoundsFired(object sender, EventArgs args)
        {
            _roundsFired++;
            Debug.WriteLine("Round fired!");
        }
    }
}
