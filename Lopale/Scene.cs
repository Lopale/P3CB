using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lopale
{
    abstract public class Scene // Class abrstaite : on ne peux pas l'instancier directement, il faut la dériver; public : tout le monde peut y accèder
    {
        protected MainGame mainGame;
        protected List<IActor> listActors;
        public Scene (MainGame pGame)
        {
            mainGame = pGame;
            listActors = new List<IActor>();
        }

        public void Clean()
        {

            listActors.RemoveAll(item => item.ToRemove == true);
        }
        
        public virtual void Load() // Virtuel pour être dérivé obligatoirement
        {

        }
        public virtual void UnLoad()
        {

        }
        public virtual void Update(GameTime gameTime)
        {
            foreach(IActor actor in listActors)
            {
                actor.Update(gameTime);
            }
        }
        public virtual void Draw(GameTime gameTime)
        {
            foreach (IActor actor in listActors)
            {
                actor.Draw(mainGame.spriteBatch);
            }

        }
    }
}
