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
            Console.WriteLine("==================================================================================");
            Console.WriteLine("Now processing " + patient.GetName() + ", with a " + patient.GetProblem().ToString() + " health problem.");

            Node patientLoc = entrance;
            patientLoc = treatmentStep(patient, patientLoc, NodeType.INFODESK);
            patientLoc = treatmentStep(patient, patientLoc, NodeType.GP);
            patientLoc = treatmentStep(patient, patientLoc, pickDiagnostic(patient.GetProblem()));
            patientLoc = treatmentStep(patient, patientLoc, NodeType.GP);
            patientLoc = treatmentStep(patient, patientLoc, NodeType.TREATMENT);
            patientLoc = treatmentStep(patient, patientLoc, NodeType.ENTRANCE);
        }

        Node treatmentStep(Patient patient, Node start, NodeType end) {
            Console.WriteLine("Now leading the patient to the nearest " + end.ToString() + ".");
            var path = _layout.GetPath(start, end);
            Console.WriteLine("Path cost: " + path.GetCost(patient.GetSpeedMultiplier()));
            printPath(path);
            return path.GetLinks().Last().GetTo();
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

        void printPath(Path path) {
            Console.Write("Path taken: ");
            foreach (var link in path.GetLinks()) Console.Write(link.GetFrom().ToString() + " -> ");
            Console.WriteLine(path.GetLinks().Last().GetTo().ToString());
        }

        Patients _patients;
        Graph _layout;
        List<NavRequest> _navRequests;
    }
}
