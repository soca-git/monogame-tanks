using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
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

            SoundEffectsManager.Add("explosion", "explosion04", Content);

            SongsManager.Add("background", "Brothers In Arms March (128 kbps)", Content);

            MediaPlayer.Play(SongsManager.Get("background"));
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Volume *= 0.1f;

            Tank = new Tank(TexturesManager.Get("tank"), 100, 100, 0.5f, Color.Wheat);
        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }

            // TODO: Add your update logic here
            Tank.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here. The order of drawing matters!
            _spriteBatch.Begin();

            // Draw
            _spriteBatch.Draw(TexturesManager.Get("background"), _backgroundSize, Color.White);

            if (Tank != null)
            {
                Tank.Draw(_spriteBatch);
            }

            _spriteBatch.DrawString(FontsManager.Get("default"), "Tanks very much!", new Vector2(5, _screenHeight - 20), Color.Aquamarine);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
