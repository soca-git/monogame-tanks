using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Tanks.ContentManagers;
using Tanks.Sprites;
using Tanks.Utils;

namespace Tanks
{
    public class TanksGame : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private const int _screenWidth = 800;
        private const int _screenHeight = 600;
        private readonly Rectangle _backgroundSize = new Rectangle(0, 0, _screenWidth, _screenHeight);

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
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            if (Tank == null)
            {
                Tank = new Tank(TexturesManager.Get("tank"), 100, 100, 0.5f, Color.Wheat);
            }

            var keyState = Keyboard.GetState();

            Tank.UpdatePosition(keyState);

            if (keyState.IsKeyDown(Keys.Space) && Shell == null)
            {
                var orientation = Tank.CurrentOrientation().ToVector2();
                var shellPosition = Tank.CurrentPosition() + 55 * orientation;
                Shell = new Shell(TexturesManager.Get("shell"), shellPosition.X, shellPosition.Y, 0.5f, Color.White, 400, Tank.CurrentOrientation());
            }

            if (Shell != null)
            {
                Shell.Update(gameTime);

                if (Shell.HasExploded())
                {
                    Explosion = new Explosion(TexturesManager.Get("explosion"), Shell.CurrentPosition().X, Shell.CurrentPosition().Y, 0.5f, Color.White);
                    Explosion.Explode(gameTime);
                    Shell = null;
                }
            }

            if (Explosion != null)
            {
                Explosion.Update(gameTime);

                if (Explosion.HasExploded())
                {
                    Explosion = null;
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
            _spriteBatch.Draw(TexturesManager.Get("background"), _backgroundSize, Color.White);

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

            _spriteBatch.DrawString(FontsManager.Get("default"), "Tanks very much!", new Vector2(5, _screenHeight - 20), Color.Aquamarine);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
