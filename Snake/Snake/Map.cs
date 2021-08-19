using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake {
    class Map {
        public Map(int width, int height, IMapTile defaultTile) {
            _mapData = new IMapTile[width, height];
            for (int i = 0; i < Width; ++i) {
                for (int j = 0; j < Height; ++j) {
                    _mapData[i, j] = MapTile.Empty;
                }
            }
        }

        public IMapTile GetTile(int x, int y) {
            return _mapData[x, y];
        }

        public void SetTile(IMapTile tile, int x, int y) {
            _mapData[x, y] = tile;
        }

        public int Width { get; private set; }
        public int Height { get; private set; }

        IMapTile[,] _mapData;
    }
}
