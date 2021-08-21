using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake {
    class KeyboardController : IPlayerController {
        public KeyboardController() {
            _keyboard = Keyboard.GetKeyboard();
            _revTime = 0;
            _gameEnd = false;
            _time = new TimeDelta();
        }

        public Direction? GetInput() {
            // This method doesn't look that appealing,
            // I'll leave it for now, and I'll think about a better way to do this
            // (if I don't forget)
            while (_keyboard.HasKey()) {
                switch(_keyboard.GetKey()) {
                    case ConsoleKey.UpArrow:
                        return _revTime <= 0 ? Direction.Up : Direction.Down;
                    case ConsoleKey.DownArrow:
                        return _revTime <= 0 ? Direction.Down : Direction.Up;
                    case ConsoleKey.LeftArrow:
                        return _revTime <= 0 ? Direction.Left : Direction.Right;
                    case ConsoleKey.RightArrow:
                        return _revTime <= 0 ? Direction.Right : Direction.Left;
                    case ConsoleKey.Escape:
                        _gameEnd = true;
                        return null;
                }
            }
            return null;
        }

        public bool IsEndGame() {
            return _gameEnd;
        }

        public void Reverse(long millis) {
            _revTime = millis;
        }

        public void Update() {
            _keyboard.Update();
            _revTime -= _revTime > 0 ? _time.DeltaTime() : 0;
            _time.Update();
        }

        Keyboard _keyboard;
        long _revTime;
        bool _gameEnd;
        TimeDelta _time;
    }
}
