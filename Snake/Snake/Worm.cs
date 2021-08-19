using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake {
    class Worm {
        public void Move() {
            // TODO: Implement
        }

        public void Grow(int i) {
            // TODO: Implement
        }

        public void Die() {
            // TODO: Implement
        }

        public bool IsAlive() {
            // TODO: Implement

            return false;
        }

        public int GetGrowCount() {
            // TODO: Implement

            return 0;
        }

        public Location GetHeadLocation() {
            // TODO: Implement

            return new Location(0, 0);
        }

        public Direction GetHeading() {
            // TODO: Implement

            return null;
        }

        public void SetHeading(Direction heading) {
            // TODO: Implement
        }

        public IPlayerController GetController() {
            // TODO: Implement

            return new KeyboardController();
        }

        public void SetController(IPlayerController c) {
            // TODO: Implement
        }
    }
}
