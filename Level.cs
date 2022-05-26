using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Numerics;
using System.Text;

namespace Lopale
{
    class Level
    {

        public Texture2D[] spritelist;
        public void loadLevel(string pLevel)
        {



            string[] data = File.ReadAllLines("Content/Levels/"+ pLevel);
            int nbLine = 0;
            foreach (var line in data)
            {
                int nbCol = 0;
                string[] colums = line.Split(',');
                foreach (var col in colums)
                {
                    // Traitement

                  if (col != "0")
                    {
                        /*  Brick bk = new Brick(mainGame.Content.Load<Texture2D>("brick0" + col));
                        bk.Position = new Vector2(
                                 nbCol * bk.Texture.Width,
                                 nbLine * bk.Texture.Height
                             );
                         listActors.Add(bk);
                        */
                        Debug.WriteLine(col);
                    }
                  



                    Debug.WriteLine("L'id à la ligne {0} et colonne {1} est {2}", nbLine, nbCol, col);
                    nbCol++;
                }
                nbLine++;
            }
            Debug.WriteLine(data);

        }

    }
}
