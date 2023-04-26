using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Monogame_2._2_Assignment___Checkers_Board
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Texture2D rectangleTexture;
        int sqrStartX = 0, sqrStartY = 0;
        Rectangle playSquares;
        int tileSize = 80;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            
        }

        protected override void Initialize()
        {
            _graphics.PreferredBackBufferWidth = 640;
            _graphics.PreferredBackBufferHeight = 640;
            _graphics.ApplyChanges();

            rectangleTexture = Content.Load<Texture2D>("rectangle");
            playSquares = new Rectangle(sqrStartX, sqrStartY, 80, 80);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            
            // TODO: use this.Content to load your game content here
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
            GraphicsDevice.Clear(Color.Beige);
            _spriteBatch.Begin();
            for (int i = 0; i < 8; i++) // goes down the grid, allowing the next for loop to fill in each row correctly
            {
                for (int j = (i % 2) * -1; j < 8; j++)
                {
                    if ((j + i % 2) % 2 != 0) // if j is odd and i is odd:
                    {
                        _spriteBatch.Draw(rectangleTexture, new Rectangle(j * tileSize, i * tileSize, tileSize, tileSize), Color.Black);
                    }
                    else // if the opposite ^ is true:
                    {
                        _spriteBatch.Draw(rectangleTexture, new Rectangle(j * tileSize, i * tileSize, tileSize, tileSize), Color.Tan);
                    }
                }
                
            }
            
            

            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}