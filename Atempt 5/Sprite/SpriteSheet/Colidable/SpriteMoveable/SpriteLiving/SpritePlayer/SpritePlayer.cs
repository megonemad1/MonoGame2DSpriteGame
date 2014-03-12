using Atempt_5.Sprite.SpriteSheet.Gui;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Atempt_5.Sprite.SpriteSheet.Effect;

namespace Atempt_5.Sprite.SpriteSheet.Colidable.SpriteMoveable.SpriteLiving.SpritePlayer
{
    class SpritePlayer : SpriteLiving
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

       
        Vector2 GunCoolDown = new Vector2(0,0);
  
        HealthBar healthbar;
        public SpritePlayer( Microsoft.Xna.Framework.Vector2 position, Microsoft.Xna.Framework.Rectangle? srcrectangle, Microsoft.Xna.Framework.Color hue, float rotation, Microsoft.Xna.Framework.Vector2? origin, float scale, SpriteEffects effect, float depth, float THealth, int spriteWidth, int spriteHeight, HealthBar PlayerHealth)
            : base( position, srcrectangle, hue, rotation, origin, scale, effect, depth, THealth)
        {
            speed = new Vector2(4,4);
            healthbar = PlayerHealth;
        }
        public override float Clife
        {
            get
            {
                return base.Clife;
            }
            set
            {
                healthbar.SetHealthValue(value, this.Tlife);
                defaultFrameRefrenceY = SpriteHeight-(int)Math.Ceiling(Clife / Tlife * (SpriteHeight+1));
                if (defaultFrameRefrenceY >= SpriteHeight)
                    defaultFrameRefrenceY = SpriteHeight - 1;
                if (defaultFrameRefrenceY < 0)
                    defaultFrameRefrenceY = 0;
                if (value <= 0)
                {
                    Entitys.Add(new Explosion(this.position,null,Color.White,0,null,0.25f, SpriteEffects.None,0.5f));
                }
                base.Clife = value;

            }
        }
        public override bool Kill()
        {
            
            return base.Kill()&&healthbar.Kill();
        }
        public override void Update(GameTime gameTime, Game game)
        {
            KeyboardState K = Keyboard.GetState();

            if (K.IsKeyDown(Keys.W))
            {
                this.MovementDirectionX =  (float)Math.Sin(rotation);
                this.MovementDirectionY = -1*(float)Math.Cos(rotation);
                Moving = true;

            }
            

            if (K.IsKeyDown(Keys.S))
            {
                this.MovementDirectionY =  (float)Math.Cos(rotation);
                this.MovementDirectionX = -1* (float)Math.Sin(rotation);
                
                Moving = true;

            }
            if (K.IsKeyDown(Keys.D))
            {
               
                rotation += 0.12f;
                Moving = true;

            }
            if (K.IsKeyDown(Keys.A))
            {
               
                rotation -= 0.12f;
                Moving = true;

            }
            // TODO: Add your update logic here 
            var MouseState=Mouse.GetState();
            if (K.IsKeyDown(Keys.Space))
            {
                LookAtPoint(new Vector2(MouseState.X, MouseState.Y));

            }
           
            if(GunCoolDown.X<=0&&K.IsKeyDown(Keys.E))
            {
                Entitys.Add(new Atempt_5.Sprite.SpriteSheet.Colidable.SpriteMoveable.SpriteObstical.ammo.Lazer.Lazer(this.position+new Vector2((float)(20*Math.Cos(rotation)),20*(float)Math.Sin(rotation)), null, Color.White, this.rotation, null, 1f, effect, 0.5f,this));
                GunCoolDown.X = 2;
            }
            if (K.IsKeyDown(Keys.Q) && GunCoolDown.Y <= 0)
            {
                Entitys.Add(new Atempt_5.Sprite.SpriteSheet.Colidable.SpriteMoveable.SpriteObstical.ammo.Lazer.Lazer(this.position + new Vector2((float)(-20 * Math.Cos(rotation)), -20 * (float)Math.Sin(rotation)), null, Color.White, this.rotation, null, 1f, effect, 0.5f,this));
                GunCoolDown.Y = 2;
            }
            if(GunCoolDown.X>0)
            {
                GunCoolDown.X -= 0.1f;
            }
            if (GunCoolDown.Y>0)
            {
                GunCoolDown.Y -= 0.1f;

            }
            Vector2 Bounds = OnEdge(Game1.GameRegion);
            if (Bounds.X == -1)
            {
                position.X = Game1.GameRegion.Right + 1;
            }
            else if (Bounds.X == 1)
            {

                position.X = Game1.GameRegion.Left - 1;
            }
            if (Bounds.Y == 1)
            {

                position.Y = Game1.GameRegion.Bottom + 1;
            }
            else
                if (Bounds.Y == -1)
                {
                    position.Y = Game1.GameRegion.Top - 1;
                }

          /////  if (Moving)
            //{
                if (AnimationCounter % 10 == 1)
                {

                    NextFameX();
                    Moving = false;

                }
            //}
           // else
           // {
                ///defaultFrameRefrenceX = 1;
               /// srcrectangle = DefaultAnimationFrames[defaultFrameRefrenceX, defaultFrameRefrenceY];
           // }
            position += SpriteDirection * speed;
            SpriteDirection = new Vector2(0, 0);
            base.Update(gameTime, game);

        }

    }
}
