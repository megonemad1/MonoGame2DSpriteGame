using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Atempt_5.Sprite.SpriteSheet.Colidable
{
  abstract  class SpriteColidable : SpriteSheet
    {

     
        
        //public override Texture2D SpriteTexture
        //{
        //    get
        //    {
        //        return base.SpriteTexture;
        //    }
        //    set
        //    {
        //    }
        //}
      public static List<SpriteColidable> Colidable = new List<SpriteColidable>();
      public override bool Kill()
      {
          if(!Colidable.Remove(this))
          {
              Console.WriteLine("failed To remove spriteColidable ID: "+SpriteID);
          }
          return base.Kill();
      }
        float Radius;
     
        public Vector2 OnEdge(Rectangle Rc)
        {

        //    if ((b1_x > b2_x + b2_w - 1) || // is b1 on the right side of b2?
        //(b1_y > b2_y + b2_h - 1) || // is b1 under b2?
        //(b2_x > b1_x + b1_w - 1) || // is b2 on the right side of b1?
        //(b2_y > b1_y + b1_h - 1))   // is b2 under b1?
        //    {
        //        // no collision
        //        return 0;
        //    }
 

            Vector2 RV = new Vector2(0, 0);
           if (position.X<Rc.Left)
           {
               RV.X++;
           }
           else if (position.X>Rc.Right)
           {
               RV.X--;
           }
           if (position.Y > Rc.Bottom)
           {
               RV.Y++;
           }
           else if (position.Y < Rc.Top)
           {
               RV.Y--;
           }
           return RV;

        }
        public bool coliding(SpriteColidable SpriteB)
        {
            Console.Write(SpriteB.SpriteID + " Coliding: ");
            if (Radius*scale + SpriteB.Radius*SpriteB.scale > Vector2.Distance(SpriteB.position, position))
            {
                Console.WriteLine("true");
                return true;
            }
            Console.WriteLine("false");
            return false;
        }
        public SpriteColidable(Microsoft.Xna.Framework.Vector2 position, Microsoft.Xna.Framework.Rectangle? srcrectangle, Microsoft.Xna.Framework.Color hue, float rotation, Microsoft.Xna.Framework.Vector2? origin, float scale, SpriteEffects effect, float depth)
            : base(position, srcrectangle, hue, rotation, origin, scale, effect, depth)
        {
            if (srcrectangle.HasValue)
            Radius =(float) Math.Sqrt(srcrectangle.Value.Width * srcrectangle.Value.Width + srcrectangle.Value.Height * srcrectangle.Value.Height);
            else
                if (this.Texture != null)
                {
                    float width = DefaultAnimationFrames[0, 0].Width / 2;
                    float Height = DefaultAnimationFrames[0, 0].Height / 2;
                    Radius = (float)Math.Sqrt(width*width+Height*Height);
                }
            Colidable.Add(this);
          
        }

    }
}
