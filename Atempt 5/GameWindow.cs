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
        public Rectangle? GameRegion;
        GameState name;
     

       public GameWindow(Game1 game,GameState name)
        {
            Updatable = new Dictionary<string, IUpdateable>();
            DrawableTextures = new Dictionary<string, IDrawable>();
            DrawableFont = new Dictionary<string, SpriteText>();
            this.name = name;
        }
       public bool Update(GameTime gameTime, Game1 game)
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

      public bool Draw(SpriteBatch SB)
       {
          try
          {
              foreach (KeyValuePair<string,IDrawable> D in DrawableTextures)
              {
                  D.Value.Draw(SB);
              }
              foreach(KeyValuePair<string,SpriteText> S in DrawableFont)
              {
                  S.Value.Draw(SB);
              }
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
