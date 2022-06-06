using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Lopale
{
    class Background : Sprite
    {
        public Background(Texture2D pTexture) : base(pTexture)
        {

            

        }

        public void deplacement()
        {
            
             this.Move(-2, 0);
            
        }
    }
}
