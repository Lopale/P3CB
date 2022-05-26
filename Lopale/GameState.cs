using System;
using System.Collections.Generic;
using System.Text;

namespace Lopale
{
    public class GameState
    {
        public enum SceneType
        {
            Menu,
            Gameplay,
            GameOver
        }

        protected MainGame mainGame;
        public Scene CurrentScene { get; set; }

        public GameState(MainGame pGame)
        {
            mainGame = pGame;
        }

        public void ChangeScene(SceneType pSceneType)
        {
            if(CurrentScene != null)
            {
                CurrentScene.UnLoad();
                CurrentScene = null;
            }

            switch (pSceneType)
            {
                case SceneType.Menu:
                    CurrentScene = new SceneMenu(mainGame);
                    break;
                case SceneType.Gameplay:
                    CurrentScene = new SceneGameplay(mainGame);
                    break;
                case SceneType.GameOver:
                    CurrentScene = new SceneGameOver(mainGame);
                    break;
                default:
                    break;
            }
            CurrentScene.Load();
        }
    }
}
