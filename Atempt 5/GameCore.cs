﻿#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

    /*   | Up | RE | DN | FE |
     * -----------------------
     * Ps| 00 | 00 | 02 | 02 |
     * -----------------------
     * Pc| 00 | 01 | 01 | 00 |
     * =======================
     * T | 00 | 01 | 03 | 02 |
     */
    public enum KeyEventStates
    { Up = 0, RisingEdge = 1, FallingEdge = 2, Down = 3 }
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class GameCore : Game
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
        #region KeyPress State
        public Keys[] PreviousState;
        #endregion
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public GameCore()
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
            gameState = GameState.Play;
            // graphics.IsFullScreen = true;
            PreviousState = Keyboard.GetState().GetPressedKeys();
            PlayWindowInint();
            PauseWindowInit();
            MenuWindowInit();





        }

        private void MenuWindowInit()
        {
            GameWindows[GameState.Menu] = new MenuWindow().setGameState(GameState.Menu);
        }

        private void PauseWindowInit()
        {
            GameState SustainVal = GameState.Pause;
            GameWindows[SustainVal] = new PauseWindow().setGameState(SustainVal);
            {
                var MsgPause = new SpriteText(FontBank["Scratch"]).SetText("Pause").SetPos(new Vector2(Window.ClientBounds.Center.X,Window.ClientBounds.Center.Y)).SetOrigen();
                GameWindows[SustainVal].DrawableFont.Add("MsgPause", MsgPause);
            }

        }
        private void PlayWindowInint()
        {

            GameState SustainVal = GameState.Play;
            {
                GameWindows[SustainVal] = new PlayWindow().setGameState(SustainVal);

                var ShipSprite = new SpriteTexture(GetNewKey(), TextureBank["ship"].texture, TextureBank["ship"].SpriteSheetSize).SetDefaultRectangle(new Vector2(0, 0)).SetOrigenCenter();
                var shipName = new SpriteText(FontBank["Scratch"]);
                shipName.Depth = 1f;
                var Player1 = new Player1Ship(ShipSprite, shipName);
                string Key = "Player1Ship";
                GameWindows[SustainVal].DrawableFont.Add(Key, shipName);
                GameWindows[SustainVal].DrawableTextures.Add(Key, ShipSprite);
                GameWindows[SustainVal].Updatable.Add(Key, Player1);
                GameWindows[SustainVal].Colideable.Add(Key, Player1);
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
            TextureBank = new Dictionary<string, SpriteSheet>();


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
            LoadTexture("HealthBar", 1, 5, "HealthBar1_5");
            #endregion
            #region explotion
            LoadTexture("Explotion", 10, 1, "Explotion10_1");
            #endregion
            #region Lazer
            LoadTexture("LazerBall", 1, 4, "LazerBall1_4");
            #endregion

            //////Font Textures
            #region Main Font
            FontBank.Add("Scratch", Content.Load<SpriteFont>("ScratchFont"));//---------------------------------------------------
            #endregion
            #region Test
            FontBank.Add("test", Content.Load<SpriteFont>("SpriteFont1"));
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


        public KeyEventStates CurrentKeyState(Keys K)
        {
            int Rval = 0;
            if (PreviousState.Contains(K))
                Rval += 2;
            if (Keyboard.GetState().IsKeyDown(K))
                Rval += 1;
            return (KeyEventStates)Rval;

        }



        Random R = new Random();
        protected override void Update(GameTime gameTime)
        {
            GameWindows[gameState].Update(gameTime, this);




            base.Update(gameTime);
            PreviousState = Keyboard.GetState().GetPressedKeys();
        }


        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {

            GraphicsDevice.Clear(Color.CornflowerBlue);


            // TODO: Add your drawing code here

            GameWindows[gameState].Draw(spriteBatch);



            base.Draw(gameTime);
        }


    }
}