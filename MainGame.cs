using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Lopale // Personnaliser selon le jeu
{
    public class MainGame : Game // Personnaliser selon le jeu
    {
        private GraphicsDeviceManager _graphics;
        public SpriteBatch spriteBatch;

        public GameState gameState;

        public MainGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            gameState = new GameState(this);

            //Service locator windows
            ServiceLocator.RegisterService<GameWindow>(Window);
            // Ajouter Variable content dans mon service Locator
            ServiceLocator.RegisterService<ContentManager>(Content);
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here


            _graphics.PreferredBackBufferWidth = 850;
            _graphics.PreferredBackBufferHeight = 700;

            _graphics.ApplyChanges();

            gameState.ChangeScene(GameState.SceneType.Menu);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            AssetManager.Load(Content);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            if(gameState.CurrentScene !=null)
            {
                gameState.CurrentScene.Update(gameTime);
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DarkGray);

            spriteBatch.Begin();

            // TODO: Add your drawing code here

            gameState.CurrentScene.Draw(gameTime);
            
            
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
