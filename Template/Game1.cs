using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Template
{

    public class Game1 : Game
    {
        //Variabler för klassen Game1
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Maputskrivare map;
        SpriteFont text;
        int slow = 10;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }


        protected override void Initialize()
        {
            Highscore.Init();

            Player.Init(Content.Load<Texture2D>("pacman"), new Rectangle(1, 1, 1, 1));
            base.Initialize();
            text = Content.Load<SpriteFont>("text");
            map = new Maputskrivare(Content.Load<Texture2D>("xwing"), Content.Load<Texture2D>("pacmanbana"), Content.Load<Texture2D>("pacman"));//Lägger in bilder
        }


        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
        }


        protected override void UnloadContent()
        {

        }

        
        protected override void Update(GameTime gameTime)
        {
            if (!Player.alive)//Om man dör
            {
                this.Exit();
            }
            //Allt uppdateras
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            Highscore.Update();
            Player.Update();
            if (slow == 0)
            {
                slow = 10;
                Player.rörelse();
                map.Update();
            }

            slow--;


            base.Update(gameTime);
        }

       
        protected override void Draw(GameTime gameTime)
        {
            //Ritar ut
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            map.Draw(spriteBatch);
            Player.Draw(spriteBatch);
            Highscore.Draw(spriteBatch,text);
            spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
