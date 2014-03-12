using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Atempt_5.Sprite.SpriteSheet.Gui
{
    class HealthBar : SpriteSheet
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




        public void SetHealthValue(float health, float TotalHealth)
        {
            if (srcrectangle.HasValue)
            {
                Rectangle Trectangle = srcrectangle.Value;
                Trectangle.Width = (int)(DefaultAnimationFrames[0, 0].Width * (health / TotalHealth));
                this.srcrectangle = Trectangle;
            }
            else
            {
                Console.WriteLine("health bar wrectangle is null ID:" + this.SpriteID);
            }
        }
        public override void Update(GameTime gameTime, Game game)
        {


            if (AnimationCounter % 100 < 25 && AnimationCounter % 5 == 1 && srcrectangle.HasValue)
            {
                Rectangle T = srcrectangle.Value;
                NextFameY();
                T.Location = srcrectangle.Value.Location;
                srcrectangle = T;
            }

            base.Update(gameTime, game);

        }
        
        
        public HealthBar(Microsoft.Xna.Framework.Vector2 position, Microsoft.Xna.Framework.Rectangle? srcrectangle, Microsoft.Xna.Framework.Color hue, float rotation, Microsoft.Xna.Framework.Vector2? origin, float scale, SpriteEffects effect, float depth)
            : base( position, srcrectangle, hue, rotation, origin, scale, effect, depth)
        {

        }
    }
}
