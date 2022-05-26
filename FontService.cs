using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace template
{

    public interface IServiceFont
    {
        void SetFont(SpriteFont pFont);
        SpriteFont GetFont();
    }

    class FontService : IServiceFont
    {

        SpriteFont mainFont;

        public FontService()
        {
            ServiceLocator.RegisterService<IServiceFont>(this);
        }

        public SpriteFont GetFont()
        {
            return mainFont;
        }

        public void SetFont(SpriteFont pFont)
        {
            mainFont = pFont;
        }

    }
}
