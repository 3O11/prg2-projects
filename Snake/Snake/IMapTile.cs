using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake {
    interface IMapTile {
        ILetter GetLetter() {
            // TODO: Implement

            return new ColoredLetter();
        }

        void Chewed(Worm worm) {
            // TODO: Implement
        }
    }
}
