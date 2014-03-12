#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
#endregion

namespace Atempt_5
{
#if WINDOWS || LINUX
    /// <summary>
    /// The main class.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Console.WriteLine("Game Start");
            using (var game = new Game1())
                game.Run();
        }
      
    }
#endif
}
