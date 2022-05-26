using System;
using System.Collections.Generic;
using System.Text;

namespace Lopale
{
    class Utils
    {
        static Random RandomGen = new Random();
    
        public static void SetRandomSeed(int pSeed)
        {
            RandomGen = new Random(pSeed); // Permet de générer les même nombres aléatoires
        }
        public static int GetInt(int pMin, int pMax)
        {
            return RandomGen.Next(pMin, pMax + 1);
        }


        public static bool CollideByBox(IActor p1, IActor p2)
        {
            return p1.BoundingBox.Intersects(p2.BoundingBox);
        }
    }


}
