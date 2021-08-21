using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake {
    class MapTileWormHead : MapTileBase {
        public MapTileWormHead() {
            _letter = new ColoredLetter(' ', ConsoleColor.Blue, ConsoleColor.Blue);
        }

        public override void Chewed(Worm worm) {
            worm.Die();
        }
    }
}
