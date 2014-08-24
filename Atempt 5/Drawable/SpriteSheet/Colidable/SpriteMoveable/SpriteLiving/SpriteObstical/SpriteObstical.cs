using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Atempt_5.Drawable.SpriteSheet.Colidable.SpriteMoveable.SpriteObstical
{
 abstract   class SpriteObstical:SpriteMoveable
    {
   
       public SpriteObstical( Microsoft.Xna.Framework.Vector2 position, Microsoft.Xna.Framework.Rectangle? srcrectangle, Microsoft.Xna.Framework.Color hue, float rotation, Microsoft.Xna.Framework.Vector2? origin, float scale, SpriteEffects effect, float depth)
            : base( position, srcrectangle, hue, rotation, origin, scale, effect, depth)
        {
        }
    }
}
