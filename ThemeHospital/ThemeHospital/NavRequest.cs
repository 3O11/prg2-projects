using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThemeHospital {
    class NavRequest {
        public NavRequest(Patient patient, Node entrance) {
            _patient = patient;
            _entrance = entrance;
        }

        public Patient GetPatient() {
            return _patient;
        }

        public Node GetEntrance() {
            return _entrance;
        }

        Patient _patient;
        Node _entrance;
    }
}
