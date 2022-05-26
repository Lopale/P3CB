using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Lopale

{


    class SceneGameplay : Scene
    {
        private readonly ScoreService Score = new ScoreService();
        private readonly ControlService Control = new ControlService();


        private KeyboardState oldKBState;

        private Racket MyRacket;
        private Ball ball;
        private Level level;
        private SoundEffect sndImpact;

        public SceneGameplay(MainGame pGame) : base(pGame)
        {
            Debug.WriteLine("New SceneGame");
        }

        public override void Load()
        {
            Debug.WriteLine("SceneGame Load");

            sndImpact = mainGame.Content.Load<SoundEffect>("explode");

            oldKBState = Keyboard.GetState();

            Rectangle Screen = mainGame.Window.ClientBounds; // Taille de l'écran

            

            // Racket
            MyRacket = new Racket(mainGame.Content.Load<Texture2D>("racket-basic"));
            MyRacket.Position = new Vector2(
                (Screen.Width / 2) - MyRacket.Texture.Width / 2,
                (Screen.Height) - (MyRacket.Texture.Height * 2)
                );

            listActors.Add(MyRacket);

            // Ball
            ball = new Ball(mainGame.Content.Load<Texture2D>("ball-basic"));
            ball.Position = new Vector2(
                 MyRacket.Position.X + MyRacket.Texture.Width / 2 - ball.Texture.Width / 2,
                 MyRacket.Position.Y - ball.Texture.Height
                 );
            listActors.Add(ball);

            // Niveau
            level = new Level();
            level.loadLevel("level01");


            base.Load();
        }

        public override void UnLoad()
        {
            Debug.WriteLine("SceneGame UnLoad");
            base.UnLoad();
        }

        public override void Update(GameTime gameTime)
        {

            //IServiceScore servScore = ServiceLocator.GetService<IServiceScore>();
            //servScore.Add(10);
            //servScore.DisplayScore();

            IServiceControl servControl = ServiceLocator.GetService<IServiceControl>();
            servControl.PressRight();



            Rectangle Screen = mainGame.Window.ClientBounds;
            
            Clean();



           // Debug.WriteLine("SceneGame Update");

            KeyboardState newKBState = Keyboard.GetState();

            MyRacket.deplacement();
            ball.lunchBall();
            ball.boudingBall();



            // Test colision
            if (Utils.CollideByBox(ball, MyRacket))
            {
                MyRacket.TouchedBy(ball);
                ball.TouchedBy(MyRacket);
                //b.vx = 0 - b.vx;

                int largeurRacket = MyRacket.Texture.Width;

                if (ball.Position.X >= MyRacket.Position.X && ball.Position.X <= MyRacket.Position.X + (largeurRacket / 4))
                {
                    Debug.WriteLine("Rebond premier quart");
                    //b.vy = (0 - b.vy)/1.5f;
                }
                if (ball.Position.X > MyRacket.Position.X + (largeurRacket / 4) && ball.Position.X <= MyRacket.Position.X + 2 * (largeurRacket / 4))
                {
                    Debug.WriteLine("Rebond deuxième quart");
                }
                if (ball.Position.X > MyRacket.Position.X + 2 * (largeurRacket / 4) && ball.Position.X <= MyRacket.Position.X + 3 * (largeurRacket / 4))
                {
                    Debug.WriteLine("Rebond troisème quart");
                }
                if (ball.Position.X > MyRacket.Position.X + 3 * (largeurRacket / 4) && ball.Position.X <= MyRacket.Position.X + 4 * (largeurRacket / 4))
                {
                    Debug.WriteLine("Rebond quatrieme quart");
                    //b.vy = (0 - b.vy) * 1.5f;
                }
                // Tant que je n'ai pas trouvé de bonne formule simple rebond ci-dessous
                ball.vy = (0 - ball.vy);



                /* b.ToRemove = true; */
                sndImpact.Play();
            }

                //oldKBState = newKBState;

                base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            //Debug.WriteLine("SceneGame Draw");
            
            mainGame.spriteBatch.DrawString(AssetManager.MainFont,
                "This is the Game !",
                new Vector2(1, 1),
                Color.White);

            base.Draw(gameTime);
        }
    }
}
