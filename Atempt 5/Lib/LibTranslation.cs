using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Atempt_5
{
    class LibTranslation
    {
        public static float LookAtPoint(Vector2 Start, Vector2 Target)
        {
            float rotation = 0;
            Vector2 Tpoint = Target - Start;
            if (Tpoint.Y != 0)
            {
                rotation = (float)Math.Atan(-1 * Tpoint.X / Tpoint.Y);
                if (Tpoint.Y > 0)
                    rotation += (float)Math.PI;
            }
            else
            {
                if (Tpoint.X < 0)
                    rotation = 0.5f * (float)Math.PI;
                else
                    if (Tpoint.X > 0)
                        rotation = 1.5f * (float)Math.PI;

            }
            return rotation;
        }
    }
}
