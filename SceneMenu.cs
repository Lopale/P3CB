using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Lopale

{
    class SceneMenu : Scene
    {
        private KeyboardState oldKBState;
        GamePadState oldGPState;
        private Button buttonPlay;
        private Song music;

        public SceneMenu(MainGame pGame) : base(pGame)
        {
            Debug.WriteLine("New SceneMenu");
        }

        public void onClickPlay(Button pSender)
        {
            mainGame.gameState.ChangeScene(GameState.SceneType.Gameplay);
        }

        public override void Load()
        {
            Debug.WriteLine("SceneMenu Load");

            music = mainGame.Content.Load<Song>("music/menu");
            MediaPlayer.Play(music);
            MediaPlayer.IsRepeating = true;

            Rectangle Screen = mainGame.Window.ClientBounds;
            buttonPlay = new Button(mainGame.Content.Load<Texture2D>("button"));
            buttonPlay.Position = new Vector2(
                (Screen.Width / 2) - buttonPlay.Texture.Width / 2,
                (Screen.Height / 2) - buttonPlay.Texture.Height / 2
                );
            buttonPlay.onClick = onClickPlay;

            listActors.Add(buttonPlay);

            oldKBState = Keyboard.GetState();
            oldGPState = GamePad.GetState(PlayerIndex.One, GamePadDeadZone.IndependentAxes);
            base.Load();
        }

        public override void UnLoad()
        {
            Debug.WriteLine("SceneMenu UnLoad");
            MediaPlayer.Stop();
            base.UnLoad();
        }

        public override void Update(GameTime gameTime)
        {
            Debug.WriteLine("SceneMenu Update");
            KeyboardState newKBState = Keyboard.GetState();

            /* Pad */
            GamePadCapabilities capabilities = GamePad.GetCapabilities(PlayerIndex.One); //Test si il y a une manette
            GamePadState newGPState;
            bool BtnA = false;

            if (capabilities.IsConnected)
            {
                newGPState = GamePad.GetState(PlayerIndex.One, GamePadDeadZone.IndependentAxes);
                if(newGPState.IsButtonDown(Buttons.A) == true && oldGPState.IsButtonDown(Buttons.A) == false)
                {
                    BtnA = true;
                }
            }

            /* Souris */
            MouseState newMState = Mouse.GetState();
            if (newMState.RightButton == ButtonState.Pressed)
            {
                mainGame.gameState.ChangeScene(GameState.SceneType.Gameplay);
            }

            /* Clavier */
            if ((Keyboard.GetState().IsKeyDown(Keys.Enter) && !oldKBState.IsKeyDown(Keys.Enter)) ||
                BtnA
                )
            {
                //Debug.WriteLine("Go to the game");
                mainGame.gameState.ChangeScene(GameState.SceneType.Gameplay);
            }

            oldKBState = newKBState;
            if (capabilities.IsConnected)
            {
                newGPState = GamePad.GetState(PlayerIndex.One, GamePadDeadZone.IndependentAxes);
            }
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {

            mainGame.spriteBatch.DrawString(AssetManager.MainFont,
                "This is the menu ! Press Enter or Right Click",
                new Vector2(1,1),
                Color.White);
            // Tester manette popur changer affichage

            base.Draw(gameTime);
        }

    }
}
