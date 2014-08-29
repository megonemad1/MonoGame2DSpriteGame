#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
using Atempt_5.GameWindows;


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

        public void ReturnKey(int Key)
        {
            FreeID.Push(Key); 
        }

        #endregion
        #region GameWindows
        public Dictionary<GameState, GameWindow> GameWindows;
        #endregion
        #region FontBank
        public Dictionary<string, SpriteFont> FontBank;
        #endregion
        #region TextureBank
        Dictionary<string, SpriteSheet> TextureBank;
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
            Console.WriteLine("Game Init");
            base.Initialize();
            gameState = GameState.Menu;
            graphics.IsFullScreen = true;

            PlayWindowInint();
            PauseWindowInit();
            MenuWindowInit();
            
           


           
        }

        private void MenuWindowInit()
        {
            GameWindows[GameState.Menu] = new GameWindow().setGameState(GameState.Menu);
        }

        private void PauseWindowInit()
        {
            GameWindows[GameState.Pause] = new PauseWindow().setGameState(GameState.Pause);
        }
        private void PlayWindowInint()
        {

            GameState SustainVal = GameState.Play;
            {
                GameWindows[SustainVal] = new GameWindow().setGameState(SustainVal);

                var ShipSprite = new SpriteTexture(GetNewKey(), TextureBank["ship"].texture, TextureBank["ship"].SpriteSheetSize).SetDefaultRectangle(new Vector2(0, 0)).SetOrigenCenter();
                string Key = "Player1Ship";
                GameWindows[SustainVal].DrawableTextures.Add(Key, ShipSprite);
                GameWindows[SustainVal].Updatable.Add(Key, new Player1Ship(ShipSprite, this));
            }

            {
                string Key = "Curser";
                SpriteTexture CurserTexture = new SpriteTexture(GetNewKey(), TextureBank[Key].texture, TextureBank[Key].SpriteSheetSize).SetOrigenCenter().SetDepth(1f);
                GameWindows[SustainVal].DrawableTextures.Add(Key, CurserTexture);
                GameWindows[SustainVal].Updatable.Add(Key, new Curser(CurserTexture));

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
            
            GameWindows = new Dictionary<GameState, GameWindow>();
            TextureBank = new Dictionary<string,SpriteSheet>();
          

            FontBank = new Dictionary<string, SpriteFont>();
            spriteBatch = new SpriteBatch(GraphicsDevice);
            //////Image Textures
            #region Curser
            LoadTexture("Curser", 11, 1, "Curser");
            #endregion
            #region Ship
                LoadTexture("ship", 4, 4, "ship4_4");
            #endregion
            #region HealthBar
            LoadTexture("HealthBar",1,5,"HealthBar1_5");
            #endregion
            #region explotion
            LoadTexture("Explotion", 10, 1, "Explotion10_1");
            #endregion
            #region Lazer
            LoadTexture("LazerBall", 1, 4, "LazerBall1_4");
            #endregion

            //////Font Textures
            #region Main Font
            FontBank.Add("Main Font",Content.Load<SpriteFont>("Main Font"));//---------------------------------------------------
            #endregion 

           
        }

        private void LoadTexture(string Key, int x, int y, string textureName)
        {
            try
            {
                Console.WriteLine("loading " + Key);
                TextureBank.Add(Key, new SpriteSheet(Content.Load<Texture2D>(textureName), x, y));

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
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

            foreach (KeyValuePair<string, IUpdateable> U in GameWindows[gameState].Updatable)
            {
                U.Value.Update(gameTime, this);
            }

            if (Keyboard.GetState().IsKeyDown( Keys.P))
            {
                gameState = GameState.Play;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.O))
            {
                gameState = GameState.Pause;
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

            spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.NonPremultiplied);
            // TODO: Add your drawing code here


            foreach (KeyValuePair<string, IDrawable> S in GameWindows[gameState].DrawableTextures)
            {
                S.Value.Draw(spriteBatch);
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }


    }
}
