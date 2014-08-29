using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Atempt_5
{
    class SpriteSheet
    {
        public Texture2D texture { get { return _texture; } }
        public Vector2 SpriteSheetSize { get { return _SpriteSheetSize; } }
        
        Texture2D _texture;
        Vector2 _SpriteSheetSize;

        /// <summary>
        /// used to store both the texture and how to divide it up inorder to get an indivitual sprite (a vector of 1,1 will not be divided)
        /// </summary>
        /// <param name="texture">The Visual Reprisentation</param>
        /// <param name="SpriteSheetSize">The number of sprites in the width of the Tezture as X and Hight of the Tezture As Y</param>
        public SpriteSheet(Texture2D texture, Vector2 SpriteSheetSize)
        {
            this._texture = texture;
            this._SpriteSheetSize = SpriteSheetSize;
        }
        /// <summary>
        /// used to store both the texture and how to divide it up inorder to get an indivitual sprite (a X & Y Value of 1,1 will not be divided)
        /// </summary>
        /// <param name="texture">The Visual Reprisentation</param>
        /// <param name="X">The number of sprites in the width of the Texture</param>
        /// <param name="Y">The number of sprites in the Height of The Texture</param>
        public SpriteSheet(Texture2D texture, float X,float Y)
        {
            this._texture = texture;
            this._SpriteSheetSize = new Vector2(X, Y);
        }
    }
}
