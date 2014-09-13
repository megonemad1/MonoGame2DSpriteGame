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
           Coliding(gameTime, game);
           
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

       private void Coliding(GameTime gameTime, GameCore game)
       {
           Dictionary<Vector2, List<IColideable>> Boxes = new Dictionary<Vector2, List<IColideable>>();
           foreach (KeyValuePair<string,IColideable> i in Colideable)
           {
               Vector2 key = Lib.LibCollision.GetBox(i.Value);
               if (Boxes[key] != null)
               {
                   Boxes[key].Add(i.Value);
               }
               else
               {
                   Boxes[key] = new List<IColideable>();
                   Boxes[key].Add(i.Value);
               }
              
           }
           foreach (KeyValuePair<Vector2,List<IColideable>> c in Boxes)
           {
               Vector2 MidMid = c.Key;
               Vector2 TopMid = MidMid + new Vector2(0, -1);
               Vector2 TopRight = MidMid + new Vector2(1, -1);
               Vector2 TopLeft = MidMid + new Vector2(-1, -1);
               Vector2 MidRight = MidMid + new Vector2(1, 0);
               Vector2 MidLeft = MidMid + new Vector2(-1, 0);
               Vector2 BtmRight = MidMid + new Vector2(1, 1);
               Vector2 BtmMid = MidMid + new Vector2(0, 1);
               Vector2 BtmLeft = MidMid + new Vector2(-1, 1);
               List<IColideable> box = new List<IColideable>();
               box.AddRange(Boxes[TopLeft]);
               box.AddRange(Boxes[TopMid]);
               box.AddRange(Boxes[TopRight]);
               box.AddRange(Boxes[MidLeft]);
               box.AddRange(Boxes[MidMid]);
               box.AddRange(Boxes[MidRight]);
               box.AddRange(Boxes[BtmLeft]);
               box.AddRange(Boxes[BtmMid]);
               box.AddRange(Boxes[BtmRight]);
               if (box.Count>1)
               {

               }
               
              

               

           }
       }

      public virtual bool Draw(SpriteBatch SB)
       {
          try
          {
              Matrix GlobalScale =Matrix.CreateScale(GameSettings.ResolutionRescale);
              SB.Begin(SpriteSortMode.FrontToBack, BlendState.NonPremultiplied, null, null, null, null, GlobalScale);
              foreach (KeyValuePair<string,IDrawable> D in DrawableTextures)
              {
                  D.Value.Draw(SB);
              }
              SB.End();
              SB.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend,null,null,null,null,GlobalScale);
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
