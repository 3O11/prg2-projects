using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake {
    class MapTile {
        public static MapTileEmpty Empty {
            get {
                if (_emptyTile == null) _emptyTile = new MapTileEmpty();
                return _emptyTile;
            }
            private set {
                _emptyTile = value;
            }
        }
        public static MapTileEdible Edible {
            get {
                if (_edibleTile == null) _edibleTile = new MapTileEdible();
                return _edibleTile;
            }
            private set {
                _edibleTile = value;
            }
        }
        public static MapTileWine Wine {
            get {
                if (_wineTile == null) _wineTile = new MapTileWine();
                return _wineTile;
            }
            private set {
                _wineTile = value;
            }
        }
        public static MapTileWormKiller WormKiller {
            get {
                if (_killerTile == null) _killerTile = new MapTileWormKiller();
                return _killerTile;
            }
            private set {
                _killerTile = value;
            }
        }

        static MapTileEmpty _emptyTile;
        static MapTileEdible _edibleTile;
        static MapTileWine _wineTile;
        static MapTileWormKiller _killerTile;
    }
}
