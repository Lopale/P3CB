using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lopale
{
    public interface IActor
    {
        Vector2 Position { get; }
        Rectangle BoundingBox { get; } // Hitbox
        void Update(GameTime pGamtime);
        void Draw(SpriteBatch pSpriteBatch);
        void TouchedBy(IActor pBy);
        bool ToRemove { get; set; }

    }
}
