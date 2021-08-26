using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake {
    class MapTileEdible : MapTileBase {
        public MapTileEdible(int growCount) {
            _letter = new ColoredLetter(' ', ConsoleColor.Red, ConsoleColor.Red);
            _growCount = growCount;
        }

        public override void Chewed(Worm worm) {
            worm.Grow(_growCount);
        }

        int _growCount;
    }
}
