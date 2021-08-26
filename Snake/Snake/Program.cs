using System;

namespace Snake {
    class Program {
        static void Main(string[] args) {
            bool run = true;
            while (run) {
                Console.WriteLine("Please select the size of the playing field that you would like: ");
                int width = GetInt("Width");
                int height = GetInt("Height");
                bool drawBorders = GetBool("Should there be visible borders?");

                Game game = new Game(width, height, drawBorders);
                game.Run();

                run = GetBool("Try again?");
            }
            
        }

        static int GetInt(string message) {
            Console.Write(message + ": ");
            int value;
            string input = Console.ReadLine();
            while (!int.TryParse(input, out value)) {
                Console.Write("Invalid input, please try again: ");
                input = Console.ReadLine();
            }

            return value;
        }

        static bool GetBool(string message) {
            Console.Write(message + " (Y/n): ");
            while (true) {
                ConsoleKey key = Console.ReadKey().Key;
                if (key == ConsoleKey.Y) return true;
                if (key == ConsoleKey.N) return false;
                Console.Write("\nInvalid input, please try again: ");
            }

        }
    }
}
