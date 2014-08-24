using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Atempt_5
{
    class TBRActor
    {
        bool dead;
        internal virtual void Update(Microsoft.Xna.Framework.GameTime gameTime, Game1 game)
        {
            if (dead)
            {
                game.Updatable.Remove(this);

            }
            
        }
        public virtual void Kill()
        {
            dead = true;
            //Console.WriteLine("Removed Sprite ID: " + SpriteID);
            //FreeID.Add(this.SpriteID);
            //return Entitys.Remove(this);
        }

    }
}
