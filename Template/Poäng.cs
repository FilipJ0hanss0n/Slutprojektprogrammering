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
    class Poäng:Bas
    {
        public  bool tagen = false; //En bool som säger ifall poängen är upptagen eller inte
        public Rectangle Pos
        {
            get { return pos; }
        }

        public Poäng(Rectangle r, Texture2D t)
        {
            pos = r;
            pixel = t; 
        }

        public void Update() //Uppdaterar griden
        {
            Mapgenerator.map_grid[pos.X, pos.Y] = 0;
        }
    }
}
