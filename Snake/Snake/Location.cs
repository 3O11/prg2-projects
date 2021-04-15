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

        int GetX() { return x; }
        int GetY() { return y; }

        int x, y;
    }
}
