using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Atempt_5.GameWindows
{
    class GameIni:GameWindow
    {
        public GameIni()
        {

        }

        public override bool Update(GameTime gameTime, GameCore game)
        {
           // Viewport V = game.GetViewport();
           // GameSettings.CurrentResolution = new Point(V.Width, V.Height);
            game.gameState = GameState.Play;
            return base.Update(gameTime, game);
        }

        public override bool Draw(SpriteBatch SB)
        {
            return base.Draw(SB);
        }
    }
}
