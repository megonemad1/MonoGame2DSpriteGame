using Atempt_5.Drawable.SpriteSheet.Effect;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Atempt_5.Drawable.SpriteSheet.Gui;
using Microsoft.Xna.Framework;

namespace Atempt_5.Drawable.SpriteSheet.Colidable.SpriteMoveable.SpriteLiving.Mob
{
    class MobShip : Mob
    {
        //static HelthBar MobHelthBar;
        HealthBar MobHealthBar;
        bool HasTask;
        int Task;
        Vector2? Target;
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
        

        Vector2 GunCoolDown = new Vector2(0, 0);
      public  MobShip(Vector2 position, Rectangle? srcrectangle, Color hue, float rotation, Vector2? origen, float scail, SpriteEffects effect, float depth, float health)
            : base(position, srcrectangle, hue, rotation, origen, scail, effect, depth, health)
        {
            MobHealthBar = new HealthBar(this.position + new Vector2(0, -32), null, Color.White, 0f, null, 0.25f, SpriteEffects.None, 0.6f);
           
        }
        public override float Clife
        {
            get
            {
                return base.Clife;
            }
            set
            {
                MobHealthBar.SetHealthValue(value, this.Tlife);
                defaultFrameRefrenceY = SpriteHeight - (int)Math.Ceiling(Clife / Tlife * (SpriteHeight + 1));
                if (defaultFrameRefrenceY >= SpriteHeight)
                    defaultFrameRefrenceY = SpriteHeight - 1;
                if (defaultFrameRefrenceY < 0)
                    defaultFrameRefrenceY = 0;
                if (value <= 0)
                {
                    Entitys.Add(new Explosion(this.position, null, Color.White, 0, null, 0.25f, SpriteEffects.None, 0.5f));
                }
                base.Clife = value;

            }
        }
        public override bool Kill()
        {

            return base.Kill() && MobHealthBar.Kill();
        }

        public override void Update(GameTime gameTime, Game game)
        {
            if (!HasTask)
            {
                Task = R.Next(3);
                HasTask = true;
                Console.WriteLine(Task);
            }

            switch (Task)
            {
                case 0:
                    LookAtPoint(Game1.player as Sprite);
                    if (GunCoolDown.X < 0)
                    {
                        Entitys.Add(new Atempt_5.Drawable.SpriteSheet.Colidable.SpriteMoveable.SpriteObstical.ammo.Lazer.Lazer(this.position + new Vector2((float)(20 * Math.Cos(rotation)), 20 * (float)Math.Sin(rotation)), null, Color.White, this.rotation, null, 1f, effect, 0.5f,this));
                        GunCoolDown.X = 5;
                    }
                    HasTask = false;
                    break;

                case 1:
                    LookAtPoint(Game1.player as Sprite);
                    if (GunCoolDown.Y < 0)
                    {
                        Entitys.Add(new Atempt_5.Drawable.SpriteSheet.Colidable.SpriteMoveable.SpriteObstical.ammo.Lazer.Lazer(this.position + new Vector2((float)(-20 * Math.Cos(rotation)), -20 * (float)Math.Sin(rotation)), null, Color.White, this.rotation, null, 1f, effect, 0.5f,this));
                        GunCoolDown.Y = 5;
                    }
                    HasTask = false;
                    break;
                case 2:
                    if (Target==null)
                    {
                        Target = new Vector2(R.Next(Game1.GameRegion.Width)+Game1.GameRegion.X, R.Next(Game1.GameRegion.Height) + Game1.GameRegion.Y);
                    }
                    LookAtPoint(Target.Value);
                     this.MovementDirectionY =  (float)Math.Cos(rotation);
                this.MovementDirectionX = -1* (float)Math.Sin(rotation);
                if (Math.Abs(position.X - Target.Value.X) < 32 && Math.Abs(position.Y - Target.Value.Y) < 32)
                {
                    HasTask = false;
                    Target = null;
                }

                    break;
            }





            if (GunCoolDown.X > 0)
            {
                GunCoolDown.X -= 0.1f;
            }
            if (GunCoolDown.Y > 0)
            {
                GunCoolDown.Y -= 0.1f;

            }

            base.Update(gameTime, game);
            MobHealthBar.position = this.position + new Vector2(0, -32);
        }
    }
}
