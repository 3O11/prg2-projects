using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake {
    class Location {
        public Location(int x, int y) {
            this.x = x;
            this.y = y;
        }

        public int GetX() {
            return x;
        }

        public int GetY() {
            return y;
        }

        public Location GetMoved(Direction dir) {
            return new Location(x + dir.dX(), y + dir.dY());
        }

        int x;
        int y;
    }
}
