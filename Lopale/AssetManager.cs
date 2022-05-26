using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lopale
{
    class AssetManager
    {
        public static SpriteFont MainFont { get; private set; }

        public static void Load(ContentManager pContent)
        {
            MainFont = pContent.Load<SpriteFont>("mainfont");

        }
    }
}
