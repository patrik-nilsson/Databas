using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Morters_Kundapp
{

    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SquareDrawer sd;
        Texture2D rectTex;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            DatabaseResolver.Connect();
            rectTex = new Texture2D(GraphicsDevice, 1, 1);
            rectTex.SetData<Color>(new Color[] { Color.White });
            sd = new SquareDrawer(GraphicsDevice,Vector2.Zero,rectTex);
        }

        protected override void Update(GameTime gameTime)
        {
            //if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            //    Exit();
<<<<<<< HEAD
            if (Keyboard.GetState().IsKeyDown(Keys.A))
                DatabaseResolver.Connect();

=======
            KeyMouseReader.Update();
            if (KeyMouseReader.LeftClick())
                DatabaseResolver.GetTavling();
>>>>>>> 5233d9116ddd9a2b830c7d856a26338bc2975c37
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.LightGray);

            spriteBatch.Begin();
            sd.Draw(spriteBatch);
            spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
