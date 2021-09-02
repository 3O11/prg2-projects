using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming {
    class LCS {
        public static List<int> LongestCommonSubsequence(List<int> a, List<int> b) {
            int[,] cache = new int[a.Count + 1, b.Count + 1];

            for (int i = 0; i <= a.Count; ++i) cache[i, b.Count] = a.Count - i + 1;
            for (int i = 0; i <= b.Count; ++i) cache[a.Count, i] = b.Count - i + 1;

            for (int i = 0; i < a.Count; ++i) {
                for (int j = 0; j < b.Count; ++j) {
                    int delta = a[i] == b[j] ? 2 : 0;
                    cache[i, j] = Math.Min(delta + cache[i + 1, j + 1], Math.Min(1 + cache[i + 1, j], 1 + cache[j, i + 1]));
                }
            }

            printCache(cache, a.Count + 1, b.Count + 1);

            return null;
        }

        public static void printCache(int[,] cache, int n, int m) {
            for (int i = 0; i < n; ++i) {
                for (int j = 0; j < m; ++j) {
                    Console.Write(cache[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        public static string Diff(string before, string after) {
            return "";
        }
    }
}
