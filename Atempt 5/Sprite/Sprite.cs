using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Atempt_5.Sprite
{
   abstract class Sprite
    {
       
        public float AnimationCounter = 0;
        private static int nextkey = 0;
        public int SpriteID;
        public static List<Sprite> Entitys = new List<Sprite>();
        public static List<int> FreeID = new List<int>();
        public float Depth;
    
        public virtual void draw(SpriteBatch SB)
        {if (Texture!=null)
            SB.Draw(Texture, position, null, hue, 0f, new Microsoft.Xna.Framework.Vector2(0, 0), 1f, SpriteEffects.None, Depth);
        }
        public Sprite(Microsoft.Xna.Framework.Vector2 position, Microsoft.Xna.Framework.Color hue,float Depth)
        {
            this.hue = hue;
            this.position = position;
           

            if (FreeID.Count == 0)
            {
                SpriteID = nextkey;
                nextkey++;
            }
            else
            {
                SpriteID = FreeID[0];
                FreeID.RemoveAt(0);
            }

                this.Depth = Depth;
        }
        public virtual bool Kill()
        {
            Console.WriteLine("Removed Sprite ID: " + SpriteID);
            FreeID.Add(this.SpriteID);
            return Entitys.Remove(this);
        }
       

        public virtual void Update(GameTime gameTime,Game game)
        {
            AnimationCounter++;
        }
        public abstract Texture2D Texture { get; set; }
        public Microsoft.Xna.Framework.Vector2 position;
        public Microsoft.Xna.Framework.Color hue;
    }
}
