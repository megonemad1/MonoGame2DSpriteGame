﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Atempt_5.GameWindows
{
    class PauseWindow : GameWindow
    {
        public PauseWindow()
        {
        }
        
        public override bool Update(GameTime gameTime, GameCore game)
        {
            if (game.CurrentKeyState(Keys.P) == KeyEventStates.RisingEdge)
            {
                game.gameState = GameState.Play;
            }

           
            return base.Update(gameTime, game);

        }

        public override bool Draw(SpriteBatch SB)
        {
            return base.Draw(SB);
        }
    }
}
