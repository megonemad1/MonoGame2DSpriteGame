using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Atempt_5
{
  public  interface IColideable
    {
        Vector2 Pos { get; }
        float Radius { get; }
        float Rotation { get; }
        Rectangle? BoundingBox { get; }

        public void Colision(IColideable C);
    }
}
