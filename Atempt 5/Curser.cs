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
            //var mouse= Mouse.GetState();
        //curser = new SpriteTexture((TextureKey, new Vector2(0, 0), 0.8f, game);//new Vector2(mouse.X, mouse.Y), 1f, game);
        //curser.Texture = game.TextureBank[TextureKey];
        //curser.origin=new Vector2(game.TextureBank[TextureKey].Width/2,game.TextureBank[TextureKey].Height/2);
        //curser.scale = 0.5f;
       
        }
       public void Update(GameTime gameTime, GameCore game1)
        {
          var mouse= Mouse.GetState();
          curser.position = new Vector2(mouse.X, mouse.Y);
        }
    }
}
