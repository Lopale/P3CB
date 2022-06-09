using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace Lopale
{
    class Level
    {

        public List<IActor> listBrick;
        public void loadLevel(string pLevel)
        {
            listBrick = new List<IActor>();

            var contentManager = ServiceLocator.GetService<ContentManager>();

            Rectangle Screen = ServiceLocator.GetService<GameWindow>().ClientBounds;

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

                        if (col == "9")
                        {

                            BrickSpecial bk = new BrickSpecial(contentManager.Load<Texture2D>("brick0" + col));
                            bk.Position = new Vector2(
                               // Remplacer le 10 par de l'automatique
                               ((Screen.Width) - (10 * bk.Texture.Width)) / 2 + nbCol * bk.Texture.Width,
                               ((Screen.Height) - (10 * bk.Texture.Height)) / 2 + nbLine * bk.Texture.Height

                           );
  //                          Debug.WriteLine("Nb coup = "+bk.life);
                            listBrick.Add(bk);
                        }
                        else { 
                            Brick bk = new Brick(contentManager.Load<Texture2D>("brick0" + col));
                        

                              bk.Position = new Vector2(
                                  // Remplacer le 10 par de l'automatique
                                 ((Screen.Width) - (10 * bk.Texture.Width)) / 2 + nbCol * bk.Texture.Width,
                                 ((Screen.Height) - (10 * bk.Texture.Height)) / 2 + nbLine * bk.Texture.Height

                             );
                            listBrick.Add(bk);
                        }
                        //listActors.Add(bk);
                        //listBrick.Add(bk);

                        Debug.WriteLine(col);
                    }
                  



                    //Debug.WriteLine("L'id à la ligne {0} et colonne {1} est {2}", nbLine, nbCol, col);
                    nbCol++;
                }
                nbLine++;
            }
//            Debug.WriteLine(data);

        }




    }
}
