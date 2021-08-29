using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaycastingEngine {
    class Player {
        public Player(Vec2 pos, Vec2 dir) {
            Position = pos;
            Direction = dir;
            _movementSpeed = 0.1f;
        }

        public void Move() {
            Position = Position + (Direction * _movementSpeed);
        }

        public Vec2 Position { get; private set; }
        public Vec2 Direction { get; private set; }
        double _movementSpeed;
    }
}
