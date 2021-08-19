using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake {
    class Game {
        Game() {
            _gameMap = new GameMap();
        }

        public void Run() {
            TimeDelta time = new TimeDelta();

            while (!_shouldExit) {
                if (time.DeltaTime() >= 100) {
                    Update();
                    time.Update();
                }
            }
        }

        void Update() {
            Console.WriteLine("wergh");

            var worm = _gameMap.GetWorm();
            worm.Move();
        }

        bool _shouldExit = false;
        GameMap _gameMap;
    }
}
