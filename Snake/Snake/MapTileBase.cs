using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake {
    abstract class MapTileBase : IMapTile {
        ILetter GetLetter() {
            // TODO: Implement

            return new ColoredLetter();
        }
    }
}
