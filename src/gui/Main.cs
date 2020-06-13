using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace gui
{
    public class Main : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private Dictionary<string, Texture2D> sprites = new Dictionary<string, Texture2D>();

        private string[] spriteAssets = new string[] {
            "Background",
            "Needle"
        };    

        float needlePosition = 0;

        public Main()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferHeight = 800;
            graphics.PreferredBackBufferWidth = 800;
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
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // Load all content from *Assets lists:
            foreach (var asset in spriteAssets)
            {
                sprites.Add(asset, Content.Load<Texture2D>(asset));
            }
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            var keyState = Keyboard.GetState();

            if(keyState.IsKeyDown(Keys.Up) && needlePosition <= 180)
            {
                needlePosition += 0.1f;
            }
            else if(needlePosition >= 0) 
            {
                needlePosition -= 0.05f;
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            // TODO: Add your drawing code here
            spriteBatch.Draw(
                sprites["Background"],
                new Vector2(400, 400),
                null,
                Color.White,
                0,
                new Vector2(300, 300),
                1.0f,
                SpriteEffects.None,
                0.0f
            );

            spriteBatch.Draw(
                sprites["Needle"],
                new Vector2(400, 400),
                null,
                Color.White,
                needlePosition,
                new Vector2(300, 300),
                1.0f,
                SpriteEffects.None,
                0.0f
            );
            base.Draw(gameTime);
            spriteBatch.End();
        }
    }
}
