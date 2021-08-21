using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake {
    abstract class MapTileBase : IMapTile {
        public virtual ILetter GetLetter() {
            return _letter;
        }
        public abstract void Chewed(Worm worm);

        protected ILetter _letter;
    }
}
