using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake {
    class MapTileBorder : MapTileBase {
        public MapTileBorder() {
            _letter = new ColoredLetter(' ', ConsoleColor.Gray, ConsoleColor.Gray);
        }

        public override void Chewed(Worm worm) {
            // This tile is purely cosmetic, the snake will never meet it.
        }
    }
}
