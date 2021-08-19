using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake {
    class GameMap {
        public GameMap() {
            _map = new Map(30, 30, MapTile.Empty);
            _worm = new Worm();
        }

        public void Render() {
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
            // TODO: Implement
        }

        public Worm GetWorm() {
            return _worm;
        }

        Map _map;
        Worm _worm;
    }
}
