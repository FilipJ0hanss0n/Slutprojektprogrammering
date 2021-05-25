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
    class Maputskrivare : IDraw, IUpdate
    {
        //Variabler för klassen
        private int wallsize = 20;
        private List<Fiende> Fiender = new List<Fiende>();
        private Texture2D tex;
        private List<Poäng> poäng = new List<Poäng>();
        private static int pointchecker = 0;
        private Texture2D vägg;
        public static int Points
        {
            get { return pointchecker; }
        }

        public Maputskrivare(Texture2D t, Texture2D m, Texture2D V)
        {
            tex = t;
            vägg = V;
            Mapgenerator.init(m);
            ladda();
        }

        public void ladda()
        {
            for (int x = 0; x < Mapgenerator.map_grid.GetLength(0); x++)
            {
                for (int y = 0; y < Mapgenerator.map_grid.GetLength(1); y++)
                {
                    if (Mapgenerator.map_grid[x, y] == 0)//Poäng
                    {
                        poäng.Add(new Poäng(new Rectangle(x, y, 1, 1),tex));
                    }

                    if (Mapgenerator.map_grid[x, y] == 2)//Lägg till fiende
                    {
                        Fiender.Add(new Fiende(new Rectangle(x, y, 1, 1)));
                    }

                    else if(Mapgenerator.map_grid[x, y] == 3)//spelarens spawn
                    {
                        Player.Set(new Vector2(x, y));
                    }
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {


            for (int x = 0; x < Mapgenerator.map_grid.GetLength(0); x++)
            {
                for (int y = 0; y < Mapgenerator.map_grid.GetLength(1); y++)
                {
                    if (Mapgenerator.map_grid[x, y] == 1)//Vägg
                    {
                        spriteBatch.Draw(vägg, new Rectangle(x * wallsize, y * wallsize, wallsize, wallsize),Color.Black);
                    }

                    else if (Mapgenerator.map_grid[x, y] == 0)//Poäng
                    {
                        spriteBatch.Draw(tex, new Rectangle((x * wallsize)+wallsize/3, (y * wallsize)+wallsize/3, wallsize/2, wallsize/2), Color.White);
                    }
                    else if (Mapgenerator.map_grid[x, y] == 2)//Fiende
                    {
                        spriteBatch.Draw(tex, new Rectangle(x * wallsize, y * wallsize, wallsize, wallsize), Color.Red);
                    }
                }
            }
        }

        private void pointcheck() //Checkar poängen
        {
            for (int i = poäng.Count - 1; i >= 0; i--)
            {
                if (poäng[i].Pos.Intersects(Player.Pos))
                {
                    poäng[i].tagen = true;
                }

                if (poäng[i].tagen)
                {
                    poäng.RemoveAt(i);
                    pointchecker++;
                }
            }
        }

        public void Update() //Uppdaterar poäng och fiende
        {
            pointcheck();

            for (int i = poäng.Count - 1; i >= 0; i--)
            {
                poäng[i].Update();
            }
            for (int i = Fiender.Count - 1; i>=0; i--)
            {
                if (Fiender[i].Pos.Intersects(Player.Pos))
                {
                    Player.alive = false;
                }
                Fiender[i].Update();
            }
        }
    }
}
