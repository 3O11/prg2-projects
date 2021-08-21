using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake {
    class MapTileWine : MapTileBase {
        public MapTileWine() {
            _letter = new ColoredLetter(' ', ConsoleColor.DarkMagenta, ConsoleColor.DarkMagenta);
        }

        public override void Chewed(Worm worm) {
            worm.GetController().Reverse(5000);
            worm.SetAteWine();
        }
    }
}
