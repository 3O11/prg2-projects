using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake {
    class MapTileWormKiller : MapTileBase {
        public override void Chewed(Worm worm) {
            worm.Die();
        }
    }
}
