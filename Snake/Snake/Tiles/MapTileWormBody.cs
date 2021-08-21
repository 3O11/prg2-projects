using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake {
    class MapTileWormBody : MapTileBase {
        public MapTileWormBody() {
            _letter = new ColoredLetter(' ', ConsoleColor.Yellow, ConsoleColor.Yellow);
        }

        public override void Chewed(Worm worm) {
            worm.Die();
        }
    }
}
