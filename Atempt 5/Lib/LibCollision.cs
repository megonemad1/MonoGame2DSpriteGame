using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Atempt_5.Lib
{
    class LibCollision
    {
        public static bool CircleColiding(IColideable C1, IColideable C2)
        {
          float Dist=  Vector2.Distance(C1.Pos, C2.Pos);
          float Diameter = C1.Radius + C2.Radius;
          return (Dist <= Diameter);
        }

        public static bool? BoundingBox(IColideable C1,IColideable C2)
        {
            return null;
        }

        public static Vector2 GetBox(IColideable C)
        {
            Vector2 BoxSize = new Vector2(GameSettings.VirtualResilution.X / 10, GameSettings.VirtualResilution.Y / 10);
            Vector2 BoxPos = C.Pos / BoxSize;
            return new Vector2((int)BoxPos.X, (int)BoxPos.Y);
            
        
        }


    }
}
