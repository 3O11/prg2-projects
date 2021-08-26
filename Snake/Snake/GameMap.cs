using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake {
    class GameMap {
        public GameMap(int width = 30, int height = 30, bool drawBorders = true) {
            _map = new Map(width, height);
            _worm = new Worm();
            _rand = new Random();
            _borders = drawBorders;
        }

        public void Render() {
            Console.Clear();

            if (_borders) {
                for (int i = 0; i < _map.Width + 2; ++i) MapTile.Border.GetLetter().Write();
                Console.WriteLine();
            }
            for (int i = 0; i < _map.Height; ++i) {
                if (_borders) MapTile.Border.GetLetter().Write();
                for (int j = 0; j < _map.Width; ++j) {
                    _map.GetTile(j, i).GetLetter().Write();
                }
                if (_borders) MapTile.Border.GetLetter().Write();
                Console.Write("\n");
            }
            if (_borders) {
                for (int i = 0; i < _map.Width + 2; ++i) MapTile.Border.GetLetter().Write();
                Console.WriteLine();
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
        bool _borders;
    }
}
