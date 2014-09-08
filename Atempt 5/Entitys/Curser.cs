using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Atempt_5
{
    class Curser:IUpdateable
    {
        SpriteTexture curser;
        public Curser(SpriteTexture curser)
        {
            this.curser = curser;
         
        }
       public void Update(GameTime gameTime, GameCore game1)
        {
          var mouse= Mouse.GetState();
          curser.position = new Vector2(mouse.X, mouse.Y);
        }
    }
}
