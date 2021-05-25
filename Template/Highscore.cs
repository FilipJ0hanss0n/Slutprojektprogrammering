using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Template
{
    class Highscore
    {
        private static int score = 0;
        private static int highScore = 0;

        /// <summary>
        /// Startar binaryReader och får highscore filen
        /// </summary>
        public static void Init()
        {
            BinaryReader br = null;
            try
            {
                br = new BinaryReader(
                       new FileStream("score.data",
                       FileMode.OpenOrCreate,
                       FileAccess.Read));
                highScore = br.ReadInt32();
                br.Close();
            }
            catch
            {
                Write();
            }
            finally
            {
                if (br != null)
                    br.Close();
            }

        }

       
        /// Om highscoret nås så skrivs det ner
        
        private static void Write()
        {

            highScore = score;

            BinaryWriter br = null;

            try
            {
                br = new BinaryWriter(
                    new FileStream("score.data",
                    FileMode.OpenOrCreate,
                    FileAccess.Write));
                br.Write(highScore);
                br.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (br != null)
                    br.Close();
            }
        }

        public static void Update()
        {
            score = Maputskrivare.Points;

            if (score > highScore)
            {
                Write();
            }
        }

        public static void Draw(SpriteBatch spriteBatch, SpriteFont text)
        {
            
            spriteBatch.DrawString(text,"score: "+score+ " high score: " + highScore, new Vector2(180, 10), Color.Orange);
         
        }
    }
}
