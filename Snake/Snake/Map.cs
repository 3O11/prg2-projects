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

        public Location WrapAround(Location loc) {
            int x = loc.GetX();
            int y = loc.GetY();

            while (x < 0) x += Width;
            while (x > Width - 1) x -= Width;

            while (y < 0) y += Height;
            while (y > Height - 1) y -= Height;

            return new Location(x, y);
        }

        public void DrawWorm(Worm worm) {
            var segments = worm.GetSegments();
            foreach (var segment in segments) {
                var mapLoc = WrapAround(segment);
                _mapData[mapLoc.GetX(), mapLoc.GetY()] = MapTile.WormBody;
            }
            var headMapLoc = WrapAround(segments.First());
            _mapData[headMapLoc.GetX(), headMapLoc.GetY()] = MapTile.WormHead;
        }

        public int Width { get; private set; }
        public int Height { get; private set; }

        IMapTile[,] _mapData;
    }
}
