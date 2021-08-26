using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThemeHospital {
    class Patient {
        public Patient(string name, int speedMult, HealthProblem problem) {
            _name = name;
            _speed = speedMult;
            _problem = problem;
        }

        public string GetName() {
            return _name;
        }

        public int GetSpeedMultiplier() {
            return _speed;
        }

        public HealthProblem GetProblem() {
            return _problem;
        }

        string _name;
        int _speed;
        HealthProblem _problem;
    }
}
