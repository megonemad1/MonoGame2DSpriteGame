using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Atempt_5.Sprite.SpriteSheet.Effect
{
    class Explosion : SpriteSheet
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

      
        public override void Update(Microsoft.Xna.Framework.GameTime gameTime, Microsoft.Xna.Framework.Game game)
        {
            if (AnimationCounter % 3 == 0)
            {
                defaultFrameRefrenceX++;
                if (defaultFrameRefrenceX < SpriteWidth)
                    srcrectangle = DefaultAnimationFrames[defaultFrameRefrenceX, defaultFrameRefrenceY];
                else if (defaultFrameRefrenceX == SpriteWidth + 1)
                {
                    if (!Kill())
                    {
                        Console.WriteLine("faild to kill effect ID: " + SpriteID);
                    }
                }
            }
            base.Update(gameTime, game);

        }
        public Explosion(Vector2 position, Rectangle? srcrectangle, Color hue, float rotation, Vector2? origin, float scale, SpriteEffects effect, float depth)
            : base(position, srcrectangle, hue, rotation, origin, scale, effect, depth)
        {

        }
    }
}
