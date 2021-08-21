using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake {
    class GameMap {
        public GameMap() {
            _map = new Map(30, 30);
            _worm = new Worm();
            _rand = new Random();
        }

        public void Render() {
            Console.Clear();

            for (int i = 0; i < _map.Height; ++i) {
                for (int j = 0; j < _map.Width; ++j) {
                    _map.GetTile(j, i).GetLetter().Write();
                }
                Console.Write("\n");
            }
        }

        public Map GetMap() {
            return _map;
        }

        public void PlaceAtRandomFree(IMapTile tile) {
            int locX;
            int locY;

            while (true) {
                locX = _rand.Next() % _map.Width;
                locY = _rand.Next() % _map.Height;
                if (_map.GetTile(locX, locY).GetType() == typeof(MapTileEmpty)) {
                    _map.SetTile(tile, locX, locY);
                    break;
                }
            }
        }

        public Worm GetWorm() {
            return _worm;
        }

        Map _map;
        Worm _worm;
        Random _rand;
    }
}
