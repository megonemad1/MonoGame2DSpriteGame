using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Atempt_5
{
   public class GameWindow
    {

        public Dictionary<string, IUpdateable> Updatable;
        public Dictionary<string, IDrawable> DrawableTextures;
        public Dictionary<string, SpriteText> DrawableFont;
        public Dictionary<string, IColideable> Colideable;

        public Rectangle? GameRegion;
        GameState name;
     

       public GameWindow()
        {
            Updatable = new Dictionary<string, IUpdateable>();
            DrawableTextures = new Dictionary<string, IDrawable>();
            DrawableFont = new Dictionary<string, SpriteText>();
            Colideable = new Dictionary<string, IColideable>();
        }
       public GameWindow setGameState(GameState name)
       {
           this.name = name;
           return this;
       }
       public virtual bool Update(GameTime gameTime, GameCore game)
       {
           
           try
           {
               foreach (KeyValuePair<string,IUpdateable> U in Updatable)
               {
                   U.Value.Update(gameTime, game);
               }
               return true;
           }
           catch (Exception e)
           {
               Console.WriteLine(name + Environment.NewLine + e);
               return false;
           }
       }

      public virtual bool Draw(SpriteBatch SB)
       {
          try
          {
             SB.Begin(SpriteSortMode.FrontToBack, BlendState.NonPremultiplied);
              foreach (KeyValuePair<string,IDrawable> D in DrawableTextures)
              {
                  D.Value.Draw(SB);
              }
              SB.End();
              SB.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend);
              foreach(KeyValuePair<string,SpriteText> S in DrawableFont)
              {
                  S.Value.Draw(SB);
              }
              SB.End();
              return true;
          }
          catch (Exception e)
         {
                  Console.WriteLine(name+Environment.NewLine+e);
                  return false;
         }
       }
    }
}
