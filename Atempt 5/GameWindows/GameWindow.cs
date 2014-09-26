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
               if (Boxes.ContainsKey(key))
               {
                   Boxes[key].Add(i.Value);
               }
               else
               {
                   Boxes.Add(key, new List<IColideable>());
                   Boxes[key].Add(i.Value);
               }
              
           }
           foreach (KeyValuePair<Vector2,List<IColideable>> c in Boxes)
           {
               List<IColideable> box = new List<IColideable>();
               
               for (int i = 0; i < 3; i++)
                   for (int j = 0; j < 3; j++)
                   {
                       Vector2 Temp = new Vector2(i - 1, j - 1);
                       if(Boxes.ContainsKey(Temp))
                       {
                           box.AddRange(Boxes[Temp]);
                       }
                   }   
              
               if (box.Count>1)
               {
                   for (int i=0;i < box.Count;i++)
                       for (int j=i+1;i<box.Count;j++)
                       {
                           if (box[i].IsColiding(box[j]) || box[j].IsColiding(box[i])) 
                           {
                               box[i].Colision(box[j]);
                               box[j].Colision(box[i]);
                           }
                       }
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
