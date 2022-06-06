using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lopale
{
    class BrickSpecial: Brick
    {

        Rectangle Screen = ServiceLocator.GetService<GameWindow>().ClientBounds;
        public BrickSpecial(Texture2D pTexture) : base(pTexture)
        {

            vx = 5;
        }




        public void deplacement(int pVx)
        {


            if (this.Position.X < 0)
            {
                this.Position = new Vector2(0, this.Position.Y);
                this.vx = 0 - this.vx;
            }
            if (this.Position.X + this.BoundingBox.Width > Screen.Width)
            {
                this.Position = new Vector2(Screen.Width - this.BoundingBox.Width, this.Position.Y);
                this.vx = 0 - this.vx;
                //sndImpact.Play();
            }

        }
    }
}
