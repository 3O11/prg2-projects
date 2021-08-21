using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake {
    class Direction {
        public Direction(int dx, int dy) {
            this.dx = dx;
            this.dy = dy;
        }

        public int dX() {
            return dx;
        }

        public int dY() {
            return dy;
        }

        public Direction Reverse() {
            return new Direction(-dx, -dy);
        }

        public static bool operator==(Direction a, Direction b) {
            return (a.dx == b.dx && a.dy == b.dy);
        }

        public static bool operator !=(Direction a, Direction b) {
            return !(a == b);
        }

        public static Direction Up { get => _up; }
        public static Direction Down { get => _down; }
        public static Direction Left { get => _left; }
        public static Direction Right { get => _right; }

        int dx, dy;
        static Direction _up = new Direction(0, -1);
        static Direction _down = new Direction(0, 1);
        static Direction _left = new Direction(-1, 0);
        static Direction _right = new Direction(1, 0);
    }
}
