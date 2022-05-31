using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace Lopale
{
    class Brick : Sprite
    {
        public int life;


        public Brick(Texture2D pTexture) : base(pTexture)
        {
            life = 1;
        }

      /*  public override void TouchedBy(IActor pBy)
        {
            if (pBy is Ball)
            {
                Debug.WriteLine("Ball touche Brick 1");
            }
        } */

    }
}