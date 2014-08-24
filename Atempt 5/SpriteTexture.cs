using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Atempt_5
{
  public class SpriteTexture:IDrawable
    {
      public static float LookAtPoint(Vector2 Start, Vector2 Target)
      {
          float rotation = 0; 
          Vector2 Tpoint = Target - Start;
          if (Tpoint.Y != 0)
          {
              rotation = (float)Math.Atan(-1 * Tpoint.X / Tpoint.Y);
              if (Tpoint.Y > 0)
                  rotation += (float)Math.PI;
          }
          else
          {
              if (Tpoint.X < 0)
                  rotation = 0.5f * (float)Math.PI;
              else
                  if (Tpoint.X > 0)
                      rotation = 1.5f * (float)Math.PI;
              
          }
     return rotation;
      }
      public static Microsoft.Xna.Framework.Rectangle CreateRectangle (Vector2 Frame,string TextureKey, Game1 game)
      {
          int TH = game.TextureBank[TextureKey].Height;
          int TW = game.TextureBank[TextureKey].Width;
          int SH = game.SpriteSheetHeights[TextureKey];
          int SW = game.SpriteSheetWidths[TextureKey];
          return  new Rectangle((int)Frame.X, (int)Frame.Y, TW / SW, TH / SH);

      }
      public Microsoft.Xna.Framework.Rectangle CreateRectangle(Vector2 Frame, Game1 game)
      {
          int TH = Texture.Height;
          int TW = Texture.Width;
          int SH = game.SpriteSheetHeights[TextureKey];
          int SW = game.SpriteSheetWidths[TextureKey];
          return new Rectangle((int)Frame.X, (int)Frame.Y, TW / SW, TH / SH);

      }
        public void Draw(SpriteBatch SB)
        {
            if (Texture != null)
            {

                SB.Draw(this.Texture, this.position, this.srcrectangle, this.hue, this.rotation, this.origin, this.scale, this.effect, this.Depth);


            }
            else
            {
            
           
            Console.WriteLine("texture " + SpriteID + " is null");
           
            }
        }
        public SpriteTexture(string textureKey, Microsoft.Xna.Framework.Vector2 position, float Depth, Game1 game,GameWindow window)
        {
            this.hue = Color.White;
            this.position = position;
            this.Depth = Depth;
            SpriteID = game.GetNewKey();
            rotation = 0f;
            srcrectangle = null;
            origin = new Vector2(0, 0);
            scale = 1f;
            effect = SpriteEffects.None;
            Texture = game.TextureBank[textureKey];
            TextureKey = textureKey;
          //  window.DrawableTextures.Add(SpriteID.ToString(), this);
        }
        string TextureKey;
        public Texture2D Texture;
        public Microsoft.Xna.Framework.Vector2 position;
        public Microsoft.Xna.Framework.Color hue;
        public Microsoft.Xna.Framework.Rectangle? srcrectangle;
        public float rotation;
        public Microsoft.Xna.Framework.Vector2 origin;
        public float scale;
        public SpriteEffects effect;
        public int SpriteID;
        public float Depth;  
      
    }

}
