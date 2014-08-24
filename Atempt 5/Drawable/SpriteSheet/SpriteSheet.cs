using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Atempt_5.Drawable.SpriteSheet
{
    abstract class SpriteSheet 
    {



        public virtual void draw(SpriteBatch SB)
        {
            if (Texture != null)
            {

                SB.Draw(this.Texture, this.position, this.srcrectangle, this.hue, this.rotation, this.origin, this.scale, this.effect, this.Depth);


            }
        }
        public SpriteSheet(Microsoft.Xna.Framework.Vector2 position, float Depth, Game1 game)
        {
            this.hue = Color.White;
            this.position = position;
            this.Depth = Depth;
            SpriteID = game.GetNewKey();
            rotation = 0f;
            srcrectangle = null;
            origin = new Vector2(0, 0);
            scale = 1f;
            effect = SpriteEffects.None;
        }




        public Texture2D Texture;
        public Microsoft.Xna.Framework.Vector2 position;
        public Microsoft.Xna.Framework.Color hue;
        public Microsoft.Xna.Framework.Rectangle? srcrectangle;
        public float rotation;
        public Microsoft.Xna.Framework.Vector2 origin;
        public float scale;
        public SpriteEffects effect;
        public int SpriteID;
        public float Depth;



      









        
    }
}
