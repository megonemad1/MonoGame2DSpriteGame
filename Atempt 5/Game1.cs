#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;


#endregion

namespace Atempt_5
{
    public enum GameState
    { GameInit = 0, Play = 1, Pause = 2, Menu = 3 }
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Game
    {
        public GameState gameState;
        #region Keys
        private static int NextID = 0;                      //always has the next key to be made
        private static Stack<int> FreeID = new Stack<int>();//colection of releced keys these should be used as priority
        //if a key is required the function should be called to provide it
        public int GetNewKey()
        {//if there are no preownd keys
            if (FreeID.Count == 0)
                return NextID++;///make one
            else
                return FreeID.Pop();//there are preownd keys so use the last one of them
        }
        #endregion

        public Dictionary<GameState, GameWindow> Windows;
        public Dictionary<string, SpriteFont> FontBank;
        SpriteFont SP;
        //--------------------------------------------------------------------------------------------------------------------------------------------------------
        //Make Hight/width a vector or a size thus consolidating 
        //--------------------------------------------------------------------------------------------------------------------------------------------------------
        #region TextureBank
        public Dictionary<string, Texture2D> TextureBank { get { return textureBank; } set { textureBank = value; } }
        Dictionary<string, Texture2D> textureBank;

        public Dictionary<string, int> SpriteSheetHeights { get { return textureHeights; } set { textureHeights = value; } }
        Dictionary<string, int> textureHeights;

        public Dictionary<string, int> SpriteSheetWidths { get { return textureWidths; } set { textureWidths = value; } }
        Dictionary<string, int> textureWidths;
        #endregion
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

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

        protected override void Initialize()
        {

            // TODO: Add your initialization logic here

            gameState = GameState.Play;
            graphics.IsFullScreen = true;
            base.Initialize();
            Console.WriteLine("Game Init");
            
            {
                GameState SustainVal = GameState.Play;
                Windows[SustainVal] = new GameWindow(this, SustainVal);
                Windows[SustainVal].Updatable.Add("player1", new Ship(new Vector2(20, 20), 0.5f, "ship", this));
                Windows[SustainVal].Updatable.Add("Curser", new Curser("Curser", this));

            }
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        /// 
        public Texture2D LoadTextureFromContent(string Path)
        {
            Console.WriteLine("loading " + Path);
            return Content.Load<Texture2D>(Path);



        }
        protected override void LoadContent()
        {
            Console.WriteLine("Game Loading");
            // Create a new SpriteBatch, which can be used to draw textures.
            SP = Content.Load<SpriteFont>("Main Font");//---------------------------------------------------
            TextureBank = new Dictionary<string, Texture2D>();
            SpriteSheetHeights = new Dictionary<string, int>();
            SpriteSheetWidths = new Dictionary<string, int>();
            FontBank = new Dictionary<string, SpriteFont>();
            spriteBatch = new SpriteBatch(GraphicsDevice);
            #region Curser
            try
            {
                string Key = "Curser";
                Console.WriteLine("loading " + Key);
                setSpriteHeight(Key, 1);
                setSpriteWidth(Key, 1);
                SetTexture(Key, Content.Load<Texture2D>(@"Curser"));

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            #endregion

            #region Ship

            try
            {
                string Key = "ship";
                Console.WriteLine("loading " + Key);
                setSpriteHeight(Key, 4);
                setSpriteWidth(Key, 4);
                SetTexture(Key, Content.Load<Texture2D>(@"ship4_4"));

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            #endregion
            #region HealthBar

            try
            {
                string Key = "HealthBar";
                Console.WriteLine("loading " + Key);
                setSpriteWidth(Key, 1);
                setSpriteHeight(Key, 5);
                SetTexture(Key, LoadTextureFromContent("HealthBar1_5"));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            #endregion
            #region explotion

            try
            {
                string Key = "Explotion";
                Console.WriteLine("loading " + Key);
                setSpriteWidth(Key, 10);
                setSpriteHeight(Key, 1);
                SetTexture(Key, LoadTextureFromContent("Explotion10_1"));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            #endregion
            #region Lazer
            try
            {
                string Key = "LazerBall";
                Console.WriteLine("loading " + Key);
                setSpriteWidth(Key, 1);
                setSpriteHeight(Key, 4);
                SetTexture(Key, LoadTextureFromContent("LazerBall1_4"));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            #endregion



            // TODO: use this.Content to load your game content here
        }

        private void SetTexture(string Key, Texture2D texture2D)
        {
            TextureBank.Add(Key, texture2D);
        }

        private void setSpriteWidth(string Key, int p)
        {
            SpriteSheetWidths.Add(Key, p);
        }

        private void setSpriteHeight(string Key, int p)
        {
            SpriteSheetHeights.Add(Key, p);
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
            switch (this.gameState)
            {
                case GameState.GameInit: InGameInit(gameTime);
                    break;
                case GameState.Play: InGameUpdate(gameTime);
                    break;
                case GameState.Pause: InGamePause(gameTime);
                    break;
                case GameState.Menu: InGameMainMenu(gameTime);
                    break;
                default: Console.WriteLine("Game State Dosn't exsist in update");
                    Console.ReadLine();
                    break;
            }

            base.Update(gameTime);
        }

        private void InGameMainMenu(GameTime gameTime)
        {
            throw new NotImplementedException();
        }

        private void InGamePause(GameTime gameTime)
        {
            throw new NotImplementedException();
        }

        private void InGameUpdate(GameTime gameTime)
        {
            foreach (KeyValuePair<string, IUpdateable> U in Windows[GameState.Play].Updatable)
            {
                U.Value.Update(gameTime, this);
            }
        }

        private void InGameInit(GameTime gameTime)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {

            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.NonPremultiplied);
            // TODO: Add your drawing code here


            foreach (KeyValuePair<string, IDrawable> S in Windows[GameState.Play].DrawableTextures)
            {
                S.Value.Draw(spriteBatch);
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }


    }
}
