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
        private readonly LifeService Life = new LifeService();
        IServiceScore servScore = ServiceLocator.GetService<IServiceScore>();
        IServiceControl servControl = ServiceLocator.GetService<IServiceControl>();
        IServiceLife servLife = ServiceLocator.GetService<IServiceLife>();

        private KeyboardState oldKBState;


        private SoundEffect sndBreak;
        private SoundEffect sndExplode;

        private Racket MyRacket;
        private Racket MyRacketHaut;
        private Ball ball;
        private Level level;
        private SoundEffect sndImpact;

        private bool gameStop = false;

        public SceneGameplay(MainGame pGame) : base(pGame)
        {
            Debug.WriteLine("New SceneGame");
        }

        public override void Load()
        {

           // Debug.WriteLine("SceneGame Load");
            sndImpact = mainGame.Content.Load<SoundEffect>("sound/ball-bound");
            sndBreak = mainGame.Content.Load<SoundEffect>("sound/brick-break");
            sndExplode = mainGame.Content.Load<SoundEffect>("sound/explode");


            oldKBState = Keyboard.GetState();

            Rectangle Screen = mainGame.Window.ClientBounds; // Taille de l'écran



            // Racket
            MyRacket = new Racket(mainGame.Content.Load<Texture2D>("racket-basic"));
            MyRacket.Position = new Vector2(
                (Screen.Width / 2) - MyRacket.Texture.Width / 2,
                (Screen.Height) - (MyRacket.Texture.Height * 2)
                ); 
            
            MyRacketHaut = new Racket(mainGame.Content.Load<Texture2D>("racket-basic"));

            listActors.Add(MyRacket);

            MyRacketHaut.Position = new Vector2(
                (Screen.Width / 2) - MyRacketHaut.Texture.Width / 2,
                (MyRacketHaut.Texture.Height )
                );

            listActors.Add(MyRacketHaut);

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
            //Debug.WriteLine("SceneGame UnLoad");
            base.UnLoad();
        }

        public override void Update(GameTime gameTime)
        {

            
           
            Rectangle Screen = mainGame.Window.ClientBounds;



           // Debug.WriteLine("SceneGame Update");

            KeyboardState newKBState = Keyboard.GetState();

            MyRacket.deplacement();
            MyRacketHaut.deplacement();
            ball.lunchBall();
            ball.boudingBall();

            
            // Récupère ma liste de brique pour l'intégrer à Actor
            foreach (IActor brick in level.listBrick)// Laisser la boucle pour le multiball
            {
               listActors.Add(brick);
            }
            level.listBrick.Clear();

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

            if (Utils.CollideByBox(ball, MyRacketHaut))
            {

                MyRacketHaut.TouchedBy(ball);
                ball.TouchedBy(MyRacketHaut);

                ball.vy = (0 - ball.vy);
                sndImpact.Play();


            }

                foreach (IActor Actor in listActors)// Laisser la boucle pour le multiball
            {

                if (Actor is Brick)
                {
                    Brick br = (Brick)Actor;
                    if (Utils.CollideByBox(br, ball))
                    {
                        //br.TouchedBy(ball);
                        br.life = br.life - 1;
                        ball.TouchedBy(br);
                        //br.TouchedBy(ball);
                        ball.vy = 0 - ball.vy;
                        sndImpact.Play();

                        if (br.life <= 0)
                        {
                            servScore.Add(10);
                            br.ToRemove = true;
                            sndBreak.Play();
                        }
                    }
                }
            }

            //oldKBState = newKBState;

            /* Pas top, a améliorer*/
            if (ball.BallLost)
            {
                ball.BallLost = false;
                servLife.Subtract(1);
                gameStop = true;
            }
            if (servLife.GetLife() <= 0)
            {
                mainGame.gameState.ChangeScene(GameState.SceneType.GameOver);
            }

            if (gameStop)
            {

                if (servControl.PressEnter())
                {
                    gameStop = false;
                    Debug.WriteLine("Nouvelle Balle ! ");
                    // Ball
                    ball = new Ball(mainGame.Content.Load<Texture2D>("ball-basic"));
                    ball.Position = new Vector2(
                         MyRacket.Position.X + MyRacket.Texture.Width / 2 - ball.Texture.Width / 2,
                         MyRacket.Position.Y - ball.Texture.Height
                         );
                    listActors.Add(ball);
                }
            }


            Clean();

             base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            //Debug.WriteLine("SceneGame Draw");

            /*  mainGame.spriteBatch.DrawString(AssetManager.MainFont,
                  "This is the Game !",
                  new Vector2(1, 1),
                  Color.White);
            */
            mainGame.spriteBatch.DrawString(AssetManager.MainFont,
                servScore.DisplayScore(),
                new Vector2(1,380),
                Color.White);

            mainGame.spriteBatch.DrawString(AssetManager.MainFont,
                   servLife.DisplayLife(),
                  new Vector2(1, 350),
                  Color.White);

            base.Draw(gameTime);

        }
    }
}
