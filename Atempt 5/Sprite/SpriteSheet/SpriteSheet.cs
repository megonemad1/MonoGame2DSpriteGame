using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Atempt_5.Sprite.SpriteSheet
{
    abstract class SpriteSheet : Sprite
    {

        public int defaultFrameRefrenceX = 0;
        public int defaultFrameRefrenceY = 0;
        public Microsoft.Xna.Framework.Rectangle? srcrectangle;
        public float rotation;
        public Microsoft.Xna.Framework.Vector2 origin;
        public float scale;
        public SpriteEffects effect;
        public float depth;
        public abstract int SpriteHeight { get; set; }
        public abstract int SpriteWidth { get; set; }

        public abstract Rectangle[,] DefaultAnimationFrames { get; }





        public override void draw(SpriteBatch SB)
        {
            SB.Draw(this.Texture, this.position, this.srcrectangle, this.hue, this.rotation, this.origin, this.scale, this.effect, this.depth);

        }

        public void SetFrame(int x, int y)
        {
            if (x * y >= 0)
            {
                Console.WriteLine("a negitive frame refrence was sent ID:" + SpriteID);
                defaultFrameRefrenceX = (int)Math.Abs(x) % SpriteWidth;
                defaultFrameRefrenceY = (int)Math.Abs(y) % SpriteHeight;


            }
            else
            {
                defaultFrameRefrenceX = (int)x % SpriteWidth;
                defaultFrameRefrenceY = (int)y % SpriteHeight;
            }

            srcrectangle = DefaultAnimationFrames[defaultFrameRefrenceX, defaultFrameRefrenceY];


        }
        public void NextFameX()
        {
            defaultFrameRefrenceX = (defaultFrameRefrenceX + 1) % SpriteWidth;
            srcrectangle = DefaultAnimationFrames[defaultFrameRefrenceX, defaultFrameRefrenceY];
        }
        public void NextFameY()
        {
            defaultFrameRefrenceY = (defaultFrameRefrenceY + 1) % SpriteHeight;
            srcrectangle = DefaultAnimationFrames[defaultFrameRefrenceX, defaultFrameRefrenceY];
        }
        public void LookAtPoint(Vector2 Target)
        {
            Vector2 Tpoint = Target - this.position;
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
        }
        public void LookAtPoint(Sprite Target)
        {
            LookAtPoint(Target.position);
        }


        public SpriteSheet(Microsoft.Xna.Framework.Vector2 position, Microsoft.Xna.Framework.Rectangle? srcrectangle, Microsoft.Xna.Framework.Color hue, float rotation, Microsoft.Xna.Framework.Vector2? origin, float scale, SpriteEffects effect, float depth)
            : base(position, hue, depth)
        {

            this.rotation = rotation;

            this.scale = scale;
            this.effect = effect;
            this.depth = depth;


            Console.WriteLine("Creating SpriteSheet Instance ID: " + SpriteID);
            this.origin = origin.HasValue ? origin.Value : new Vector2(DefaultAnimationFrames[0, 0].Width / 2, DefaultAnimationFrames[0, 0].Height / 2);
            this.srcrectangle = (srcrectangle.HasValue) ? srcrectangle : DefaultAnimationFrames[0, 0];
        }
    }
}
