using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Atempt_5
{
  public class SpriteText:IDrawable
    {
        public SpriteFont font;
        public Vector2 position;
        public Color hue;
        public string DspText;
        public float rotation;
        public Vector2 origin;
        public float scale;
        public SpriteEffects effect;
        public int SpriteID;
        public float Depth;  

        public void Draw(SpriteBatch SB)
        {
            SB.DrawString(font, DspText, position, hue, rotation, origin, scale, effect, Depth);
        }
      public  float TextHeight { get { return font.MeasureString(DspText).Y; } }
     public   float TextWidth { get { return font.MeasureString(DspText).X; } }
     public Vector2 TextSize { get { return font.MeasureString(DspText); } }
        public SpriteText(SpriteFont font)
        {
            this.font = font;
            this.position = new Vector2(0, 0);
            hue = Color.White;
            rotation = 0f;
            origin = new Vector2(0, 0);
            scale = 1f;
            effect = SpriteEffects.None;
            this.Depth = 0.5f;
        }

        public SpriteText SetText(string Text)
        {
            DspText = Text;
            return this;
        }
        public SpriteText SetPos(Vector2 Pos)
        {
            this.position = Pos;
            return this;
        }

        internal SpriteText SetOrigen(Vector2 vector2)
        {
            this.origin = vector2;
            return this;
        }

        internal SpriteText SetOrigen()
        {
            SetOrigen(TextSize / 2);
            return this;
        }
    }
}
