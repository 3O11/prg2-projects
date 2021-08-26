using System;

namespace ThemeHospital {
    class Program {
        static void Main(string[] args) {
            HospitalParser parser = new HospitalParser();
            Hospital hospital = parser.ParseSave("inputs/3.in");
            hospital.Run();
        }
    }
}
