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
    class Player
    {
        //Variabler för klassen player
        private static Texture2D pixel;
        private static Rectangle pos;
        public static bool alive = true;
        public static void Init(Texture2D skin, Rectangle coords)
        {
            pixel = skin;
            pos = coords;
        }

        
        public enum Dirr //Lägger in enum
        {
            Upp,
            Ner,
            Höger,
            Vänster
        }

        private static Dirr direction = Dirr.Upp;
        public static Rectangle Pos
        {
            get { return pos; }
        }

        public static void rörelse()//Rörelsen
        {
            if (direction == Dirr.Upp)
            {
                if (Mapgenerator.map_grid[pos.X, pos.Y - 1] != 1)
                {
                    Mapgenerator.map_grid[pos.X, pos.Y - 1] = 3;
                    Mapgenerator.map_grid[pos.X, pos.Y] = -1;
                    pos.Y--;
                }
            }
            if (direction == Dirr.Ner)
            {
                if (Mapgenerator.map_grid[pos.X, pos.Y + 1] != 1)
                {
                    Mapgenerator.map_grid[pos.X, pos.Y + 1] = 3;
                    Mapgenerator.map_grid[pos.X, pos.Y] = -1;
                    pos.Y++;
                }
            }
            if (direction == Dirr.Höger)
            {
                if (Mapgenerator.map_grid[pos.X + 1, pos.Y] != 1)
                {
                    Mapgenerator.map_grid[pos.X + 1, pos.Y] = 3;
                    Mapgenerator.map_grid[pos.X, pos.Y] = -1;
                    pos.X++;
                }
            }
            if (direction == Dirr.Vänster)
            {
                if (Mapgenerator.map_grid[pos.X - 1, pos.Y] != 1)
                {
                    Mapgenerator.map_grid[pos.X - 1, pos.Y] = 3;
                    Mapgenerator.map_grid[pos.X, pos.Y] = -1;
                    pos.X--;
                }
            }
        }
        
        public static void Set(Vector2 p)
        {
            pos.X = (int)p.X;
            pos.Y = (int)p.Y;
        }
        public static void Update()//Knappar för rörelsen
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                direction = Dirr.Upp;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                direction = Dirr.Ner;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                direction = Dirr.Vänster;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                direction = Dirr.Höger;
            }
        }
        public static void Draw(SpriteBatch spritebatch) //Poängen
        {
            Rectangle temp = new Rectangle(pos.X * 20, pos.Y * 20, 20, 20);

            spritebatch.Draw(pixel, temp, Color.White);
        }
    }
}
