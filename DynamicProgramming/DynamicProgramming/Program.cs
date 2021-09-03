using System;
using System.Collections.Generic;

namespace DynamicProgramming {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine(Keys.CountPossibleKeys(5, 5));

            Console.WriteLine(LCS.Diff("Lorem ipsum dolor, sit amet", "Loran ybsum colour, sit anet"));
            Console.WriteLine(LCS.Diff("stereotyp", "stetoskop"));
            Console.WriteLine(LCS.Diff("poutnik", "potemnik"));
            Console.WriteLine(LCS.Diff("colour", "color"));
            Console.WriteLine(LCS.Diff("color", "colour"));
            Console.Read();
        }
    }
}
