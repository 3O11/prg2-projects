using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake {
    class Worm {
        public Worm() {
            _isAlive = true;
            _startLength = 2;
            _snakeSegments = new LinkedList<Location>();
            _snakeSegments.AddFirst(new Location(2, 2));
            _heading = Direction.Right;
        }

        public void Move() {
            Direction newDirection = _playerController.GetInput();
            if (newDirection != null && newDirection.Reverse() != _heading) _heading = newDirection;

            _snakeSegments.AddFirst(_snakeSegments.First().GetMoved(_heading));

            while (_snakeSegments.Count > _growLength + _startLength) _snakeSegments.RemoveLast();
        }

        public void Grow(int i) {
            _growCount++;
            _growLength += i;
            _ateFood = true;
        }

        public void Die() {
            _isAlive = false;
        }

        public bool IsAlive() {
            return _isAlive;
        }

        public int GetGrowCount() {
            return _growCount;
        }

        public Location GetHeadLocation() {
            return _snakeSegments.First();
        }

        public Direction GetHeading() {
            return _heading;
        }

        public void SetHeading(Direction heading) {
            _heading = heading;
        }

        public IPlayerController GetController() {
            return _playerController;
        }

        public void SetController(IPlayerController c) {
            _playerController = c;
        }

        public LinkedList<Location> GetSegments() {
            return _snakeSegments;
        }

        public void SetAteWine() {
            _ateWine = true;
        }

        public bool AteWine() {
            bool ate = _ateWine;
            _ateWine = false;
            return ate;
        }

        public bool AteFood() {
            bool ate = _ateFood;
            _ateFood = false;
            return ate;
        }

        bool _isAlive;
        bool _ateWine;
        bool _ateFood;

        int _startLength;
        int _growLength;
        int _growCount;

        Direction _heading;
        LinkedList<Location> _snakeSegments;

        IPlayerController _playerController;
    }
}
