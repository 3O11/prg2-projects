using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake {
    class MapTileEmpty : MapTileBase {
        public MapTileEmpty() {
            _letter = new ColoredLetter(' ', ConsoleColor.Black, ConsoleColor.Black);
        }

        public override void Chewed(Worm worm) {
            // Nothing happend when the worm touches this tile
        }
    }
}
