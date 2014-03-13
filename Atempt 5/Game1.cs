#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
using Atempt_5.Sprite;
using Atempt_5.Sprite.SpriteSheet;
using Atempt_5.Sprite.SpriteSheet.Colidable;
using Atempt_5.Sprite.SpriteSheet.Gui;
using Atempt_5.Sprite.SpriteSheet.Colidable.SpriteMoveable;
using Atempt_5.Sprite.SpriteSheet.Colidable.SpriteMoveable.SpriteLiving;
using Atempt_5.Sprite.SpriteSheet.Colidable.SpriteMoveable.SpriteLiving.SpritePlayer;
using Atempt_5.Sprite.SpriteSheet.Effect;
using Atempt_5.Sprite.SpriteSheet.Colidable.SpriteMoveable.SpriteObstical.ammo.Lazer;
using Atempt_5.Sprite.SpriteSheet.Colidable.SpriteMoveable.SpriteLiving.Mob;

#endregion

namespace Atempt_5
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Game
    {

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
      
        public static object player;
        public static Rectangle GameRegion;
        public Game1()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        bool Firework;
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
            Console.WriteLine("Game Init");
            
            int bufferY = Window.ClientBounds.Height / 20;
            int bufferX = Window.ClientBounds.Width / 20;
            GameRegion = new Rectangle(bufferX, bufferY, Window.ClientBounds.Width - (2 * bufferX), Window.ClientBounds.Height - (2 * bufferY) - 100);
            HealthBar PlayerHelthbar = new HealthBar(new Vector2(GameRegion.Left, GameRegion.Bottom + 50), null, Color.White, 0f, new Vector2(0, 0), 1f, SpriteEffects.None, 1f);
            
            PlayerHelthbar.defaultFrameRefrenceY = 4;
            Sprite.Sprite.Entitys.Add(PlayerHelthbar);
            player = new SpritePlayer(new Vector2(0, 0), null, Color.White, 0f, null, 1f, SpriteEffects.None, 0.5f, 20f, 4, 4, PlayerHelthbar);
            Sprite.Sprite.Entitys.Add(player as Sprite.Sprite);
            // HealthBar MobHelthbar = new HealthBar(new Vector2(GameRegion.Left, GameRegion.Bottom + 50), null, Color.White, 0f, new Vector2(0, 0), 1f, SpriteEffects.None, 1f);
            
         //  MobHelthbar.defaultFrameRefrenceY = 4;
            
        //  Sprite.Sprite.Entitys.Add(new MobShip(new Vector2(Game1.GameRegion.Width,GameRegion.Height),null,Color.Red,0,null,0.6f, SpriteEffects.None,0.5f,20));
            }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        /// 
        public Texture2D LoadTextureFromContent(string Path)
        {
            Console.WriteLine("loading " + Path);
            return Content.Load<Texture2D>(GameSettings.ContentPath + Path);



        }
        protected override void LoadContent()
        {
            Console.WriteLine("Game Loading");
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            #region Player
           
            SpritePlayer.SetSpriteHeight(4);
            SpritePlayer.SetSpriteWidth(4); 
            SpritePlayer.SetTexture(LoadTextureFromContent(@"ship4_4.png"));
#endregion
            #region HealthBar
           
            HealthBar.SetSpriteWidth(1);
            HealthBar.SetSpriteHeight(5);
            HealthBar.SetTexture(LoadTextureFromContent("HealthBar1_5.png"));
#endregion
            #region explotion
            
            Explosion.SetSpriteWidth(10);            
            Explosion.SetSpriteHeight(1);
            Explosion.SetTexture(LoadTextureFromContent("Explotion10_1.png"));
            #endregion
            #region Lazer
            
            Lazer.SetSpriteWidth(1);
            Lazer.SetSpriteHeight(4);
            Lazer.SetTexture(LoadTextureFromContent("LazerBall1_4.png"));
            #endregion
            #region MobShip
            MobShip.SetSpriteHeight(4);
            MobShip.SetSpriteWidth(4);
            MobShip.SetTexture(LoadTextureFromContent(@"ship4_4.png"));
            #endregion


            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
            Console.WriteLine("unload");
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        /// 
Random R = new Random();
        protected override void Update(GameTime gameTime)
        {
            KeyboardState K = Keyboard.GetState();
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            for (int i = 0; i < Sprite.Sprite.Entitys.Count; i++)
            {

                Sprite.Sprite.Entitys[i].Update(gameTime, this);

            }

if (Keyboard.GetState().IsKeyDown(Keys.J))
{
    Firework = !Firework;
}
            if(Firework)
            {
                
                Sprite.Sprite.Entitys.Add(new Explosion(new Vector2(R.Next(Window.ClientBounds.Width), R.Next(Window.ClientBounds.Height)), null, new Color(R.Next(255),R.Next(255),R.Next(255)), 0, null, 0.2f, SpriteEffects.None, 1));
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {

            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend);
            // TODO: Add your drawing code here
            foreach (Sprite.Sprite S in Sprite.Sprite.Entitys)
            {
                S.draw(spriteBatch);
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
