using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Atempt_5.GameWindows
{
    class PlayWindow: GameWindow
    {
       public PlayWindow()
        {

        }


       public override bool Update(GameTime gameTime, GameCore game)
       { bool runthrough=  base.Update(gameTime, game);
           
           
           if(game.CurrentKeyState(Keys.P)== KeyEventStates.RisingEdge)
           {
               game.gameState = GameState.Pause;
           }
            return runthrough;
         
       }

       public override bool Draw(SpriteBatch SB)
       {
           return base.Draw(SB);
       }
    }
}
