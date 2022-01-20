using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace HelloGame
{
    public class HelloGame : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Vector2 _ballPosition;
        private Vector2 _ballVelocity;
        private Texture2D _ballTexture;

        public HelloGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            Window.Title = "Hello Game";
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _ballPosition = new Vector2(GraphicsDevice.Viewport.Width/2, GraphicsDevice.Viewport.Height/2);

            System.Random random = new System.Random();
            _ballVelocity = new Vector2((float)random.NextDouble(), (float) random.NextDouble());

            _ballVelocity.Normalize();
            _ballVelocity *= 100;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            _ballTexture = Content.Load<Texture2D>("ball");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            _ballPosition += _ballVelocity * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if(_ballPosition.X < GraphicsDevice.Viewport.X || _ballPosition.X > GraphicsDevice.Viewport.Width -64)
            {
                _ballVelocity.X *= -1;
            }

            if (_ballPosition.Y < GraphicsDevice.Viewport.Y || _ballPosition.Y > GraphicsDevice.Viewport.Height - 64)
            {
                _ballVelocity.Y *= -1;
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            _spriteBatch.Draw(_ballTexture, _ballPosition, Color.White);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
