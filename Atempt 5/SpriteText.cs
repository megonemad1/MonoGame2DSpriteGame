using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Atempt_5
{
    class SpriteText:IDrawable
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

        }

        public SpriteText(string textureKey, Microsoft.Xna.Framework.Vector2 position, float Depth, Game1 game,GameWindow window)
        {
            font = 
        }
    }
}
