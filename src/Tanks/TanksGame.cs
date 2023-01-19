using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Tanks
{
    public class TanksGame : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private const int _screenWidth = 800;
        private const int _screenHeight = 600;

        private Rectangle _backgroundSize = new Rectangle(0, 0, _screenWidth, _screenHeight);

        Texture2D Background;
        SpriteFont Font;
        Tank Tank;

        Texture2D Shell;
        Vector2 ShellPosition;
        bool ShellExists;

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
            Background = Content.Load<Texture2D>("background");
            Font = Content.Load<SpriteFont>("defaultFont");

            Tank = new Tank(Content.Load<Texture2D>("Pz.Kpfw.IV-G_preview"), 0, 0, 0.5f);
            Shell = Content.Load<Texture2D>("Light_Shell");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();


            // TODO: Add your update logic here
            Vector2 movement = Vector2.Zero;

            var keyState = Keyboard.GetState();

            if (keyState.IsKeyDown(Keys.Right))
            {
                movement.X += 2;
            }

            if (keyState.IsKeyDown(Keys.Left))
            {
                movement.X -= 2;
            }

            if (keyState.IsKeyDown(Keys.Up))
            {
                movement.Y -= 2;
            }

            if (keyState.IsKeyDown(Keys.Down))
            {
                movement.Y += 2;
            }

            if (keyState.IsKeyDown(Keys.Space) && !ShellExists)
            {
                ShellPosition = new Vector2(Tank.Box.Center.X - Shell.Width / 2, Tank.Box.Bottom - Shell.Height / 2);
                ShellExists = true;
            }

            if (ShellExists)
            {
                ShellPosition.Y += 10;

                if (ShellPosition.Y > _screenHeight)
                {
                    ShellExists = false;
                }
            }

            Tank.Move(movement);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here. The order of drawing matters!
            _spriteBatch.Begin();

            // Draw
            _spriteBatch.Draw(Background, _backgroundSize, Color.White);
            Tank.Draw(_spriteBatch);
            _spriteBatch.DrawString(Font, "Tanks very much!", new Vector2(5, _screenHeight - 20), Color.Aquamarine);

            if (ShellExists)
            {
                _spriteBatch.Draw(Shell, ShellPosition, Color.White);
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
