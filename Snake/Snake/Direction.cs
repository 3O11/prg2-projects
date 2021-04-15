using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake {
    class Direction {
        // TODO: Create singleton instances

        Direction(int dx, int dy) {
            this.dx = dx;
            this.dy = dy;
        }

        public int dX() {
            return dx;
        }

        public int dY() {
            return dy;
        }

        int dx, dy;
    }
}
