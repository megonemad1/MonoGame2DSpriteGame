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

        public SpriteText(string FontKey, Microsoft.Xna.Framework.Vector2 position, float Depth, Game1 game,GameWindow window)
        {
            font = game.FontBank[FontKey];
            this.position = position;
            hue = Color.White;
            rotation = 0f;
            origin = new Vector2(0, 0);
            scale = 1f;
            effect = SpriteEffects.None;
            SpriteID = game.GetNewKey();
            this.Depth = Depth;
        }

        public SpriteText SetText(string Text)
        {
            DspText = Text;
            return this;
        }
    }
}
