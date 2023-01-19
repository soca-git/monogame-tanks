using Microsoft.Xna.Framework;
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

        Tank Tank;
        Shell Shell;

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

            Vector2 tankMovement = Vector2.Zero;

            var keyState = Keyboard.GetState();

            if (keyState.IsKeyDown(Keys.D))
            {
                tankMovement.X += 2;
            }

            if (keyState.IsKeyDown(Keys.A))
            {
                tankMovement.X -= 2;
            }

            if (keyState.IsKeyDown(Keys.W))
            {
                tankMovement.Y -= 2;
            }

            if (keyState.IsKeyDown(Keys.S))
            {
                tankMovement.Y += 2;
            }

            if (keyState.IsKeyDown(Keys.Space) && Shell == null)
            {
                Shell = new Shell(_textures["shell"], Tank.Box.Center.X, Tank.Box.Bottom, 0.5f);
            }

            if (Shell != null)
            {
                Shell.Update(gameTime);

                if (Shell.CurrentPosition().Y > _screenHeight)
                {
                    Shell = null;
                }
            }

            Tank.Move(tankMovement);

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

            _spriteBatch.DrawString(_fonts["default"], "Tanks very much!", new Vector2(5, _screenHeight - 20), Color.Aquamarine);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
