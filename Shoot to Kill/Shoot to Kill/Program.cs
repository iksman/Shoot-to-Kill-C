using System;

namespace Shoot_to_Kill {
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
            using (var game = new Game1(1000,800,false))
                game.Run();
        }
    }
#endif
}
