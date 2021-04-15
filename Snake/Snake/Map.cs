using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake {
    class Map {
        IMapTile GetTile(int x, int y) {
            // TODO: Implement

            return new MapTileEmpty();
        }

        void SetTile(IMapTile tile, int x, int y) {
            // TODO: Implement
        }
    }
}
