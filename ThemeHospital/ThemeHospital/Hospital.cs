using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThemeHospital {
    class Hospital {
        public Hospital(Patients patients, Graph layout, List<NavRequest> navRequests) {
            _patients = patients;
            _layout = layout;
            _navRequests = navRequests;
        }

        public void Run() {
            foreach (var navRequest in _navRequests) {
                healPatient(navRequest.GetPatient(), navRequest.GetEntrance());
            }
        }

        void healPatient(Patient patient, Node entrance) {
            Console.Write(patient.GetName() + ":");

            Path patientPath;
            patientPath = _layout.GetPath(entrance, NodeType.INFODESK);
            patientPath.AddLinks(_layout.GetPath(patientPath.GetEnd(), NodeType.GP).GetLinks());
            patientPath.AddLinks(_layout.GetPath(patientPath.GetEnd(), pickDiagnostic(patient.GetProblem())).GetLinks());
            patientPath.AddLinks(_layout.GetPath(patientPath.GetEnd(), NodeType.GP).GetLinks());
            patientPath.AddLinks(_layout.GetPath(patientPath.GetEnd(), NodeType.TREATMENT).GetLinks());
            patientPath.AddLinks(_layout.GetPath(patientPath.GetEnd(), NodeType.ENTRANCE).GetLinks());

            Console.Write(patientPath.GetCost(patient.GetSpeedMultiplier()) + ":");
            Console.WriteLine(patientPath.ToString());
        }

        NodeType pickDiagnostic(HealthProblem problem) {
            switch (problem) {
                case HealthProblem.CARDIAC:
                    return NodeType.EEG;
                case HealthProblem.PNEUMONIA:
                    return NodeType.XRAY;
                case HealthProblem.HIP_PAIN:
                    return NodeType.SONO;
                case HealthProblem.NEUROTIC:
                    return NodeType.PSYCHO;
                default:
                    // The compiler wouldn't stop shouting at me that "not every code path returns a value"
                    // even though this case should not be able to happen.
                    return NodeType.ENTRANCE;
            }
        }

        Patients _patients;
        Graph _layout;
        List<NavRequest> _navRequests;
    }
}
