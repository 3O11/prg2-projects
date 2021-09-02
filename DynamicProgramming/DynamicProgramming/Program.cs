using System;
using System.Collections.Generic;

namespace DynamicProgramming {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine(Keys.CountPossibleKeys(5, 5));


            LCS.LongestCommonSubsequence(new List<int> { 0, 1, 4, 9, 5, 6 }, new List<int> { 0, 2, 4, 9, 7, 6 });
            Console.Read();
        }
    }
}
