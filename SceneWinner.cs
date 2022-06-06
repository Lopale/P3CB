using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using System.Diagnostics;

namespace Lopale
{
    class SceneWinner : Scene
    {
        public SceneWinner(MainGame pGame) : base(pGame)
        {
            Debug.WriteLine("New SceneGame");
        }

        public override void Load()
        {
            Debug.WriteLine("SceneGame Load");
            base.Load();
        }

        public override void UnLoad()
        {
            Debug.WriteLine("SceneGame UnLoad");
            base.UnLoad();
        }

        public override void Update(GameTime gameTime)
        {
            Debug.WriteLine("SceneGame Update");
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            Debug.WriteLine("SceneGame Draw");
           
            mainGame.spriteBatch.DrawString(AssetManager.MainFont,
                "You Win !",
                new Vector2(1, 1),
                Color.White);
           
            base.Draw(gameTime);
        }
    }
}
