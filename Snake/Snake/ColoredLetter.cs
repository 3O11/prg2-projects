using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake {
    class ColoredLetter : ILetter {
        public ColoredLetter(char letter, ConsoleColor foreground, ConsoleColor background) {
            _letter = letter;
            _foreground = foreground;
            _background = background;
        }

        public void Write() {
            Console.ForegroundColor = _foreground;
            Console.BackgroundColor = _background;
            Console.WriteLine(_letter);
            Console.ResetColor();
        }

        char _letter;
        ConsoleColor _foreground;
        ConsoleColor _background;
    }
}
