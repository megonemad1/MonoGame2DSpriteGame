using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Atempt_5.Drawable.SpriteSheet.Colidable.SpriteMoveable.SpriteLiving.Mob
{
    abstract class Mob : SpriteLiving
    {
        public static Random R = new Random();
        
      
       public  Mob(Vector2 position, Rectangle? srcrectangle, Color hue, float rotation, Vector2? origen, float scail,SpriteEffects effect,float depth,float health) :base(position,srcrectangle,hue,rotation,origen,scail,effect,depth,health) //base(position,srcrectangle,hue,rotation,origen,scail,effect,depth,health)
        {

        }
    }
}
