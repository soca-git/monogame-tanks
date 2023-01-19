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
            Tank = new Tank(50, 100, Content.Load<Texture2D>("Pz.Kpfw.IV-G_preview"));
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
                movement.X += 1;
            }

            if (keyState.IsKeyDown(Keys.Left))
            {
                movement.X -= 1;
            }

            if (keyState.IsKeyDown(Keys.Up))
            {
                movement.Y -= 1;
            }

            if (keyState.IsKeyDown(Keys.Down))
            {
                movement.Y += 1;
            }

            Tank.Position += movement;

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here. The order of drawing matters!
            _spriteBatch.Begin();

            // Draw
            _spriteBatch.Draw(Background, _backgroundSize, Color.White);
            _spriteBatch.Draw(Tank.Texture, Tank.Box, Tank.Color);
            _spriteBatch.DrawString(Font, "Tanks very much!", new Vector2(5, _screenHeight-20), Color.Aquamarine);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
