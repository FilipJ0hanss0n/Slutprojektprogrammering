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
    class Collision //Kollsion
    {
        static public bool Rect(Rectangle first, Rectangle second)
        {
            return first.Intersects(second);
        }
    }
}
