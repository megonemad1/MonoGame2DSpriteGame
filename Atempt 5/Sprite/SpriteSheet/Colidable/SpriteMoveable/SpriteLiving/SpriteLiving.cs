using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Atempt_5.Sprite.SpriteSheet.Colidable.SpriteMoveable.SpriteLiving
{
  abstract  class SpriteLiving:SpriteMoveable
    {private float clife;
       public float Tlife;
       public static List<SpriteLiving> LivingSprites = new List<SpriteLiving>();
       public virtual float Clife
       {
           get { return clife; }
           set
           {
               clife = value;
               if (value <= 0)
                   if (!Kill())
                       Console.WriteLine("faild to kill " + this.SpriteID);
           }
       }

       
      
       public override bool Kill()
       {
           if (!LivingSprites.Remove(this))
               Console.WriteLine("failed to remove from Living List");
           return base.Kill();
       }
        
        public float Damage { get { return Tlife - Clife; } set { Clife = Tlife - value; } }

        public SpriteLiving( Microsoft.Xna.Framework.Vector2 position, Microsoft.Xna.Framework.Rectangle? srcrectangle, Microsoft.Xna.Framework.Color hue, float rotation, Microsoft.Xna.Framework.Vector2? origin, float scale, SpriteEffects effect, float depth, float THealth)
            : base(position, srcrectangle, hue, rotation, origin, scale, effect, depth)
        {
            this.Tlife = THealth;
            this.clife = THealth;
            LivingSprites.Add(this);
        }

    }
}
