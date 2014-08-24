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
        public Curser(string TextureKey, Game1 game)
        {var mouse= Mouse.GetState();
        curser = new SpriteTexture(new Vector2(mouse.X, mouse.Y), 1f, game);
        curser.Texture = game.TextureBank[TextureKey];
        curser.origin=new Vector2(game.TextureBank[TextureKey].Width/2,game.TextureBank[TextureKey].Height/2);
        curser.scale = 0.5f;
       
        }
       public void Update(GameTime gameTime, Game1 game1)
        {
          var mouse= Mouse.GetState();
          curser.position = new Vector2(mouse.X, mouse.Y);
        }
    }
}
