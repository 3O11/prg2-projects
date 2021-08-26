using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThemeHospital {
    class Patients {
        public Patients() {
            _patients = new Dictionary<string, Patient>();
        }

        public void AddPatient(Patient patient) {
            _patients[patient.GetName()] = patient;
        }

        public Patient GetPatient(String name) {
            //if (_patients.ContainsKey(name))
            return _patients[name];
        }

        Dictionary<string, Patient> _patients;
    }
}
