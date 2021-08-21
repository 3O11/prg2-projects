using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake {
    class MapTileEdible : MapTileBase {
        public MapTileEdible() {
            _letter = new ColoredLetter(' ', ConsoleColor.Red, ConsoleColor.Red);
        }

        public override void Chewed(Worm worm) {
            worm.Grow(2);
        }
    }
}
