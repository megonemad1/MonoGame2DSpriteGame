using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Atempt_5.Drawable.SpriteSheet.Colidable.SpriteMoveable.SpriteObstical.ammo.Lazer
{
    class Lazer:Ammo
    {
      
        #region Abstract.Texture.height.width.Handler
        static Texture2D tTexture;
        static int spriteHeight;
        static int spriteWidth;
        static Rectangle[,] defaultAnimationFrames;
        public override Rectangle[,] DefaultAnimationFrames
        {
            get { return defaultAnimationFrames; }
        }
        public static void SetTexture(Texture2D T)
        {
            tTexture = T;

            defaultAnimationFrames = new Rectangle[spriteWidth, spriteHeight];
            int RectWidth = T.Width / spriteWidth;
            int RectHeight = T.Height / spriteHeight;
            for (int x = 0; x < spriteWidth; x++)
                for (int y = 0; y < spriteHeight; y++)
                {
                    defaultAnimationFrames[x, y] = new Rectangle(x * RectWidth, y * RectHeight, RectWidth, RectHeight);
                }
        }
        public static void SetSpriteHeight(int H) { spriteHeight = H; }
        public static void SetSpriteWidth(int w) { spriteWidth = w; }
        #endregion
        public override Texture2D Texture { get { return tTexture; } set { SetTexture(value); } }

        public override int SpriteHeight { get { return spriteHeight; } set { spriteHeight = value; } }

        public override int SpriteWidth { get { return spriteWidth; } set { SetSpriteWidth(value); } }

        Sprite owner;
       Vector2 Grad = new Vector2(0, 0);
        public Lazer( Microsoft.Xna.Framework.Vector2 position, Microsoft.Xna.Framework.Rectangle? srcrectangle, Microsoft.Xna.Framework.Color hue, float rotation, Microsoft.Xna.Framework.Vector2? origin, float scale, SpriteEffects effect, float depth,Sprite owner)
            : base( position, srcrectangle, hue, rotation, origin, scale, effect, depth)
        {
            Grad = new Vector2((float)Math.Sin(rotation),-1*(float)Math.Cos(rotation));
            speed = new Vector2(10,10);
            this.owner = owner;
        }
        public override void Update(GameTime gameTime, Game game)
        {

            this.position += Grad * speed;
           Vector2 Bord= OnEdge(Game1.GameRegion);
            if(Bord.Length()>0)
            {
                Entitys.Add(new Effect.Explosion(this.position, null, Color.White, this.rotation, null, 0.25f, SpriteEffects.None, 0.5f));
                if(!this.Kill())
                {
                    Console.WriteLine("unable to kill Lazer ID: " + SpriteID);

                }
            }
            if(AnimationCounter%10==0)
            {
                NextFameY();
            }
            bool Colided = false;
            
            for (int i = SpriteColidable.Colidable.Count-1; SpriteColidable.Colidable.Count<=0; i--)
            {
                SpriteColidable SC = SpriteColidable.Colidable[i];
                if ((SC.SpriteID != owner.SpriteID) && SC.SpriteID != this.SpriteID && SC.coliding(this))
                {
                    if (SpriteLiving.SpriteLiving.LivingSprites.Contains(SC))
                    {
                        (SC as SpriteLiving.SpriteLiving).Damage++;

                    }
                    Colided = true;
                }

            }
            if (Colided)
            this.Kill();
            base.Update(gameTime, game);
        }
    }
}
