using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake {
    class Game {
        public Game() {
            _gameMap = new GameMap();
            _controller = new KeyboardController();
            _gameMap.GetWorm().SetController(_controller);
            _gameMap.PlaceAtRandomFree(MapTile.Edible);
            _gameMap.PlaceAtRandomFree(MapTile.Wine);
        }

        public void Run() {
            TimeDelta time = new TimeDelta();

            while (!_shouldExit) {
                if (time.DeltaTime() >= (150 - _gameMap.GetWorm().GetGrowCount())) {
                    _controller.Update();
                    Update();
                    time.Update();
                }
            }
            Console.WriteLine("GAME OVER!");
        }

        void Update() {
            if (_controller.IsEndGame()) _shouldExit = true;

            var worm = _gameMap.GetWorm();
            var map = _gameMap.GetMap();

            worm.Move();
            Location wormHeadLoc = map.WrapAround(worm.GetHeadLocation());
            map.GetTile(wormHeadLoc.GetX(), wormHeadLoc.GetY()).Chewed(worm);

            if (worm.AteFood()) _gameMap.PlaceAtRandomFree(MapTile.Edible);
            if (worm.AteWine()) _gameMap.PlaceAtRandomFree(MapTile.Wine);
            if (!worm.IsAlive()) _shouldExit = true;

            map.ClearWorm();
            map.DrawWorm(worm);

            _gameMap.Render();
            Console.WriteLine($"Score: {worm.GetGrowCount()}");
        }

        bool _shouldExit = false;
        GameMap _gameMap;
        KeyboardController _controller;
    }
}
