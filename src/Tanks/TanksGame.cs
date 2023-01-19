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

        Texture2D Tank;
        Texture2D Background;
        SpriteFont Font;

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
            Tank = Content.Load<Texture2D>("Pz.Kpfw.IV-G_preview");
            Background = Content.Load<Texture2D>("background");
            Font = Content.Load<SpriteFont>("defaultFont");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here. The order of drawing matters!
            _spriteBatch.Begin();
            _spriteBatch.Draw(Background, _backgroundSize, Color.White);
            _spriteBatch.Draw(Tank, new Rectangle(200, 50, 50, 100), Color.White);
            // Color tints can be applied when drawing the sprites. So we could have a red tank, a green tank, etc.
            // White will not apply any tint.

            _spriteBatch.DrawString(Font, "Tanks very much!", new Vector2(5, _screenHeight-20), Color.Aquamarine);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
