using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake {
    class TimeDelta {
        public TimeDelta() {
            _lastUpdateTime = CurrentTime();
        }

        public void Update() {
            _lastUpdateTime = CurrentTime();
        }

        public long CurrentTime() {
            return DateTimeOffset.Now.ToUnixTimeMilliseconds();
        }

        public long DeltaTime() {
            return CurrentTime() - _lastUpdateTime;
        }

        long _lastUpdateTime;
    }
}
