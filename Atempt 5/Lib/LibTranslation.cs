using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Atempt_5
{
    class LibTranslation
    {
        public static float? LookAtPoint(Vector2 V1, Vector2 V2)
        {
            double rotation = 0;

            if (V1 == V2)
            {
                return null;
            }
            else
            {
                if (V1.X == V2.X || V1.Y == V2.Y)
                {
                    if (V1.X == V2.X)
                    {

                        if (V1.Y > V2.Y)
                        {
                            rotation = Math.PI;
                        }
                        else
                        {
                            rotation = 0;
                        }
                    }
                    if (V1.Y == V2.Y)
                    {

                        if (V1.X > V2.X)
                        {
                            rotation = 1.5 * Math.PI;
                        }
                        else
                        {
                            rotation = MathHelper.PiOver2;
                        }
                    }
                }
                else
                {
                    double Br = Math.Atan(Math.Abs(V2.X - V1.X) / Math.Abs(V2.Y - V1.Y));
                    if (V1.X > V2.X)
                    {
                        if (V1.Y > V2.Y)
                        {
                            //4
                            rotation = MathHelper.TwoPi - Br;
                        }
                        else
                        {
                            //3
                            rotation = Br + Math.PI;
                        }
                    }
                    else
                    {
                        if (V2.Y > V1.Y)
                        {
                            //2
                            rotation = Math.PI - Br;
                        }
                        else
                        {
                            //1
                            rotation = Br;
                        }
                    }
                }
               
            }

            return (float)rotation;
        }

        internal static float? LookAtPoint(Vector2 vector2, Point point)
        {
            return LookAtPoint(vector2, new Vector2(point.X, point.Y));
        }
    }
}
//        Vector2 Tpoint = Target - Start;
//if (Tpoint.Y != 0)
//{
//    rotation = (float)Math.Atan(-1 * Tpoint.X / Tpoint.Y);
//    if (Tpoint.Y > 0)
//        rotation += (float)Math.PI;
//}
//else
//{
//    if (Tpoint.X < 0)
//        rotation = 0.5f * (float)Math.PI;
//    else
//        if (Tpoint.X > 0)
//            rotation = 1.5f * (float)Math.PI;

//}
