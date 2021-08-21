using System;

namespace Snake {
    class Program {
        static void Main(string[] args) {
            while (true) {
                Game game = new Game();
                game.Run();

                Console.Write("Start again? (Y/n): ");
                if (Console.ReadKey().Key != ConsoleKey.Y) break;
            }
            
        }
    }
}
