using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Atempt_5.Sprite.SpriteSheet.Colidable.SpriteMoveable
{
  abstract  class SpriteMoveable:SpriteColidable
    {
        public bool Moving = false;
        private Vector2 Direction = new Vector2(0, 0);
        public Vector2 SpriteDirection { get { return this.Direction; } set { Direction = value; } }
        public float MovementDirectionX
        {
            get { return (int)Direction.X; }
            set
            {
                Direction.X = (float)(value % (2 * Math.PI));
            }
        }
        public float MovementDirectionY
        {
            get { return (int)Direction.Y; }
            set
            {
                Direction.Y = (float)(value % (2 * Math.PI));
            }
        }
        public Vector2 speed=new Vector2(0,0);
        public SpriteMoveable( Microsoft.Xna.Framework.Vector2 position, Microsoft.Xna.Framework.Rectangle? srcrectangle, Microsoft.Xna.Framework.Color hue, float rotation, Microsoft.Xna.Framework.Vector2? origin, float scale, SpriteEffects effect, float depth)
            : base(position, srcrectangle, hue, rotation, origin, scale, effect, depth)
        {

        }
       
    }
}
