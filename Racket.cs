using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Lopale
{
    class Racket : Sprite
    {


        private readonly ControlService Control = new ControlService();
        Rectangle Screen = ServiceLocator.GetService<GameWindow>().ClientBounds;


        public int Life;
        IServiceControl servControl = ServiceLocator.GetService<IServiceControl>();
        public Racket(Texture2D pTexture) : base(pTexture)
        {
            Life = 100;

            servControl.PressRight();
            servControl.PressLeft();



        }



        public override void TouchedBy(IActor pBy)
        {
            if (pBy is Ball)
            {
                Debug.WriteLine("Ball touche Racket");
            }
        }

        public void deplacement()
        {
            if (servControl.PressRight())
            {
                Debug.WriteLine("right");

                if (this.Position.X >= (Screen.Width - this.Texture.Width))
                {
                    this.Position = new Vector2((Screen.Width - this.Texture.Width), this.Position.Y);
                }
                else
                {
                    this.Move(5, 0);
                }
            }

            if (servControl.PressLeft())
            {
                Debug.WriteLine("left");

                if (this.Position.X <=0)
                {
                    this.Position = new Vector2(0, this.Position.Y);
                }
                else
                {
                    this.Move(-5, 0);
                }

            }




        }
        }
}
