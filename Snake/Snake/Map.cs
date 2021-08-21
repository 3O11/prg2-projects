using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake {
    class Map {
        public Map(int width, int height) {
            Width = width;
            Height = height;
            _mapData = new IMapTile[Width, Height];
            Clear();
        }

        public IMapTile GetTile(int x, int y) {
            return _mapData[x, y];
        }

        public void SetTile(IMapTile tile, int x, int y) {
            _mapData[x, y] = tile;
        }

        public void Clear() {
            for (int i = 0; i < Width; ++i) {
                for (int j = 0; j < Height; ++j) {
                    _mapData[i, j] = MapTile.Empty;
                }
            }
        }

        public void ClearWorm() {
            for (int i = 0; i < Width; ++i) {
                for (int j = 0; j < Height; ++j) {
                    if (_mapData[i, j].GetType() == MapTile.WormBody.GetType() || _mapData[i,j].GetType() == MapTile.WormHead.GetType())
                        _mapData[i, j] = MapTile.Empty;
                    
                }
            }
        }

        public void DrawWorm(Worm worm) {
            var segments = worm.GetSegments();
            foreach (var segment in segments) {
                _mapData[segment.GetX(), segment.GetY()] = MapTile.WormBody;
            }
            _mapData[segments.First().GetX(), segments.First().GetY()] = MapTile.WormHead;
        }

        public int Width { get; private set; }
        public int Height { get; private set; }

        IMapTile[,] _mapData;
    }
}
