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
    class Mapgenerator
    {
        //Variabler för klassen mapgenerator
        private static Texture2D map_tex;
        public static int[,] map_grid;
        private static Color[,] colors2D;

        public static void init (Texture2D M)
        {
            map_tex = M;
            map_grid = new int[map_tex.Width, map_tex.Height];
            colors2D = new Color[map_tex.Width, map_tex.Height];
            GenerateLevel();
        }

        private static void GenerateLevel()
        {
            // Array 1D
            Color[] colors1D = new Color[map_tex.Width * map_tex.Height];

            // Fyller arrayn med färg från pixlar
            map_tex.GetData(colors1D);
            for (int x = 0; x < map_tex.Width; x++)
            {
                for (int y = 0; y < map_tex.Height; y++)
                {
                    // Lägger 1D arrayn i en 2D array
                    colors2D[x, y] = colors1D[x + y * map_tex.Width];
                    GenerateTile(x, y);
                }
            }
        }

        private static void GenerateTile(int x, int y)
        {

            if (colors2D[x, y] == Color.White) // Inget
            {
                map_grid[x, y] = 0;
            }
            else if (colors2D[x, y] == Color.Black) // Vägg
            {
                map_grid[x, y] = 1;
            }
            else if (colors2D[x, y] == Color.Red) // Fiende spawn
            {
                map_grid[x, y] = 2;
            }
            else if (colors2D[x, y] == Color.Blue) // Spelaren
            {
                map_grid[x, y] = 3;
            }
        }
    }
}
