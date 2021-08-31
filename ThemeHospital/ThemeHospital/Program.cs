using System;

namespace ThemeHospital {
    class Program {
        static void Main(string[] args) {
            HospitalParser parser = new HospitalParser();
            Hospital hospital = parser.ParseSave("1.in");
            hospital.Run();
        }
    }
}
