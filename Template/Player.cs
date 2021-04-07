using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Template
{
    class Player : Bas
    {
        public Player(Texture2D skin, Rectangle coords)
        {
            pixel = skin;
            pos = coords;
        }

        public Rectangle Pos
        {
            get { return pos; }
        }

        public void Update()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                pos.Y -= 2;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                pos.Y += 2;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                pos.X -= 2;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                pos.X += 2;
            }
        }
        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(pixel,pos,Color.White);
        }
    }
}
