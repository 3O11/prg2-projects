using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// I think I have made a slightly thicker wrapper around the keyboard class than I needed to, but it makes things upstream easier to manage.

// I have decided to change this class slightly for a few reasons.
// GetKey() doesn't need to return a nullable, because HasKey() exists.
// GetKey() is also more practical with ConsoleKey as a return type.

namespace Snake {
    class Keyboard {
        Keyboard() {}

        public static Keyboard GetKeyboard() {
            if (_instance == null) _instance = new Keyboard();
            return _instance;
        }

        public bool HasKey() {
            return _keyQueue.Count > 0;
        }

        public ConsoleKey GetKey() {
            return _keyQueue.Dequeue().Key;
        }

        public void Update() {
            while (Console.KeyAvailable) {
                _keyQueue.Enqueue(Console.ReadKey());
            }
        }

        Queue<ConsoleKeyInfo> _keyQueue = new Queue<ConsoleKeyInfo>();
        static Keyboard _instance;
    }
}
