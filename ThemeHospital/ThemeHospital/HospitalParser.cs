using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;

namespace ThemeHospital {
    class HospitalParser {
        public HospitalParser() {
            _linkRegex = new Regex(@"(?<node1>[A-Z]+-[0-9]+) (?<dirBackward><?)--\((?<cost>[0-9]+)\)--(?<dirForward>>?) (?<node2>[A-Z]+-[0-9]+)");
            _patientRegex = new Regex(@"(?<name>[A-Z][a-z]*):(?<speedMult>[0-9]+):(?<condition>[A-Z]+-?[A-Z]*)");
            _navRegex = new Regex(@"(?<name>[A-Z][a-z]*):(?<entrance>[A-Z]+-[0-9]+)");
            _nodeRegex = new Regex(@"(?<type>[A-Z]+)-(?<id>[0-9]+)");
        }

        public Hospital ParseSave(string filename) {
            resetHospitalData();

            StreamReader fileReader = new StreamReader(filename);
            string line = null;
            int lineCount;

            line = fileReader.ReadLine();
            int.TryParse(line, out lineCount);
            for (int i = 0; i < lineCount; ++i) parseLink(fileReader.ReadLine());

            line = fileReader.ReadLine();
            int.TryParse(line, out lineCount);
            for (int i = 0; i < lineCount; ++i) parsePatient(fileReader.ReadLine());

            line = fileReader.ReadLine();
            int.TryParse(line, out lineCount);
            for (int i = 0; i < lineCount; ++i) parseNavRequest(fileReader.ReadLine());

            return new Hospital(_patients, _layout, _navRequests);
        }

        void parseLink(string link) {
            Match m = _linkRegex.Match(link);
            if (m.Success) {
                Node node1 = parseNode(m.Groups["node1"].Value);
                Node node2 = parseNode(m.Groups["node2"].Value);
                int cost = int.Parse(m.Groups["cost"].Value); // The cost value is guaranteed to be numeric by the regex.
                if (m.Groups["dirForward"].Value != "") _layout.AddDirLink(node1, node2, cost);
                if (m.Groups["dirBackward"].Value != "") _layout.AddDirLink(node2, node1, cost);
            }
            else {
                Console.WriteLine("Invalid Link format!");
            }
        }

        void parsePatient(string patient) {
            Match m = _patientRegex.Match(patient);
            if (m.Success) {
                string name = m.Groups["name"].Value;
                int costMult = int.Parse(m.Groups["speedMult"].Value); // The speed value is guaranteed to be numeric by the regex.
                HealthProblem condition = HealthProblemUtils.GetHealthProblem(m.Groups["condition"].Value.Replace('-', '_'));
                _patients.AddPatient(new Patient(name, costMult, condition));
            }
            else {
                Console.WriteLine("Invalid Link format!");
            }
        }

        void parseNavRequest(string navRequest) {
            Match m = _navRegex.Match(navRequest);
            if (m.Success) {
                Patient patient = _patients.GetPatient(m.Groups["name"].Value);
                Node entrance = parseNode(m.Groups["entrance"].Value);
                _navRequests.Add(new NavRequest(patient, entrance));
            }
            else {
                Console.WriteLine("Invalid NavRequest format!");
            }
        }

        Node parseNode(string node) {
            Match m = _nodeRegex.Match(node);
            if (m.Success) {
                NodeType type = NodeTypeUtils.GetNodeType(m.Groups["type"].Value);
                int id = int.Parse(m.Groups["id"].Value);
                return _layout.GetOrAddNode(type, id);
            }
            else {
                Console.WriteLine("Invalid Node format!");
                return null;
            }
        }

        void resetHospitalData() {
            _layout = new Graph();
            _patients = new Patients();
            _navRequests = new List<NavRequest>();
        }

        Graph _layout;
        Patients _patients;
        List<NavRequest> _navRequests;

        Regex _linkRegex;
        Regex _patientRegex;
        Regex _navRegex;
        Regex _nodeRegex;
    }
}
