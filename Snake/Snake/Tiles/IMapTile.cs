using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake {
    interface IMapTile {
        ILetter GetLetter();
        void Chewed(Worm worm);
    }
}
