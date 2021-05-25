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
    class Fiende:Bas, IUpdate
    {
        //enum för riktning
        Player.Dirr direction = Player.Dirr.Upp;
        Random rand = new Random();

        public  Rectangle Pos
        {
            get { return pos; }
        }
        public Fiende(Rectangle r)
        {
            pos = r;
        }

        private void rörelse()//Random rörelse för fienden
        {
            if (rand.Next(1, 6) == 1)
            {
                direction = Riktning();
                rörelse();
            }
            else
            {
                if (direction == Player.Dirr.Upp)
                {
                    if (Mapgenerator.map_grid[pos.X, pos.Y - 1] != 1)
                    {
                        Mapgenerator.map_grid[pos.X, pos.Y - 1] = 2;
                        Mapgenerator.map_grid[pos.X, pos.Y] = -1;
                        pos.Y--;
                    }

                    else
                    {
                        direction = Riktning();
                        rörelse();
                    }
                }

                else if (direction == Player.Dirr.Ner)
                {
                    if (Mapgenerator.map_grid[pos.X, pos.Y + 1] != 1)
                    {
                        Mapgenerator.map_grid[pos.X, pos.Y + 1] = 2;
                        Mapgenerator.map_grid[pos.X, pos.Y] = -1;
                        pos.Y++;
                    }

                    else
                    {
                        direction = Riktning();
                        rörelse();
                    }
                }

                else if (direction == Player.Dirr.Höger)
                {
                    if (Mapgenerator.map_grid[pos.X + 1, pos.Y] != 1)
                    {
                        Mapgenerator.map_grid[pos.X + 1, pos.Y] = 2;
                        Mapgenerator.map_grid[pos.X, pos.Y] = -1;
                        pos.X++;
                    }

                    else
                    {
                        direction = Riktning();
                        rörelse();
                    }
                }

                else if (direction == Player.Dirr.Vänster)
                {
                    if (Mapgenerator.map_grid[pos.X - 1, pos.Y] != 1)
                    {
                        Mapgenerator.map_grid[pos.X - 1, pos.Y] = 2;
                        Mapgenerator.map_grid[pos.X, pos.Y] = -1;
                        pos.X--;
                    }

                    else
                    {
                        direction = Riktning();
                        rörelse();
                    }
                }
            }
        }

        private Player.Dirr Riktning() //Rikntningen för fienderna
        {
            int temp = rand.Next(1, 5);
            if (temp == 1)
            {
                return Player.Dirr.Upp;
            }

            else if (temp == 2)
            {
                return Player.Dirr.Ner;
            }

            else if (temp == 3)
            {
                return Player.Dirr.Höger;
            }

            else if (temp == 4)
            {
                return Player.Dirr.Vänster;
            }

            else
            {
                return Player.Dirr.Höger;
            }
        }

        public void Update() //Uppdaterar rörelsen
        {
            rörelse();
        }
    }
}
