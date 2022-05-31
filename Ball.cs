using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Lopale
{
    class Ball : Sprite
    {
        

        private readonly ControlService Control = new ControlService();
        IServiceControl servControl = ServiceLocator.GetService<IServiceControl>();
        Rectangle Screen = ServiceLocator.GetService<GameWindow>().ClientBounds;

        IServiceScore servScore = ServiceLocator.GetService<IServiceScore>();


        private readonly LifeService Life = new LifeService();

        IServiceLife servLife = ServiceLocator.GetService<IServiceLife>();

        public int Type;
        public bool Moving;
        public bool BallLost;
        public Ball(Texture2D pTexture) : base(pTexture)
        {

            Type = 1; // Type de ball normal
            Moving = false; // La ball est en déplacement ou non
            BallLost = false;

            vx = 0;
            vy = 0;

            servControl.PressSpace();

        }

        public override void TouchedBy(IActor pBy)
        {
            if (pBy is Racket)
            {
                Debug.WriteLine("Ball touche Racket");
            }
            if (pBy is Brick)
            {
                //Debug.WriteLine("Ball touche Brick");
                //boudingBallBrick();
            }
        }



        public void lunchBall()
        {

            if (servControl.PressSpace())
            {
                if (this.Moving == false)
                {

                    if (this.Position.X < Screen.Width / 2 - this.Texture.Width)
                    {
                        this.vx = -5;

                    }
                    else
                    {

                        this.vx = 5;
                    }
                    this.vy = -5;
                    this.Moving = true;
                    Debug.WriteLine("Ball Tiré");
                }
            }


            if (servControl.PressRight())
            {
                if (this.Moving == false)
                {
                    if (this.Position.X >= (Screen.Width -( this.Texture.Width/2))-100) // Remplacer 100 par la moitie de la taille de la raquette 
                    {
                        this.Position = new Vector2((Screen.Width - (this.Texture.Width / 2)) - 100, this.Position.Y);
                    }
                    else
                    {
                        this.Move(5, 0);
                    }
                }
            }

            if (servControl.PressLeft())
            {
                if (this.Moving == false)
                {
                    if (this.Position.X <= 0 + 100 - (this.Texture.Width / 2))
                    {
                        this.Position = new Vector2(0 + 100- (this.Texture.Width / 2), this.Position.Y);
                    }
                    else
                    {
                        this.Move(-5, 0);
                    }
                }
            }

        }


        public void boudingBall()
        {
            if (this.Position.X < 0)
            {
                this.Position = new Vector2(0, this.Position.Y);
                this.vx = 0 - this.vx;
                //sndImpact.Play();
            }
            if (this.Position.X + this.BoundingBox.Width > Screen.Width)
            {
                this.Position = new Vector2(Screen.Width - this.BoundingBox.Width, this.Position.Y);
                this.vx = 0 - this.vx;
                //sndImpact.Play();
            }
            if (this.Position.Y < 0)
            {
                this.Position = new Vector2(this.Position.X, 0);
                this.vy = 0 - this.vy;
                this.BallLost = true;
                this.ToRemove = true;
                //sndImpact.Play();
                //Debug.WriteLine("Plafond");
            }
            if (this.Position.Y + this.BoundingBox.Height > Screen.Height)
            {
//                servLife.Subtract(1);
                //Debug.WriteLine("sol");
                this.Position = new Vector2(this.Position.X, Screen.Height - this.BoundingBox.Height);
                this.vy = 0 - this.vy;
                this.BallLost = true;
                this.ToRemove = true;
                //sndExplode.Play();
            }
            

        }

        public void boudingBallBrick()
        {

        }

    }
}
