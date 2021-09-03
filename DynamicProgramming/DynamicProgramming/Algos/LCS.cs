using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming {
    class LCS {
        public static int[] LongestCommonSubsequence(int[] a, int[] b) {
            int[,] cache = new int[a.Length + 1, b.Length + 1];

            for (int i = 0; i <= a.Length; ++i) {
                for (int j = 0; j <= b.Length; ++j) {

                    if (i == 0 || j == 0) {
                        cache[i, j] = 0;
                    }
                    else if (a[i - 1] == b[j - 1]) {
                        cache[i, j] = cache[i - 1, j - 1] + 1;
                    }
                    else {
                        cache[i, j] = Math.Max(cache[i - 1, j], cache[i, j - 1]);
                    }
                }
            }

            List<int> lcs = new List<int>();
            int x = a.Length, y = b.Length;
            while (x > 0 && y > 0) {
                if (a[x - 1] == b[y - 1]) {
                    lcs.Add(a[x - 1]);
                    x--;
                    y--;
                }
                else if (cache[x - 1, y] > cache[x, y - 1]) x--;
                else y--;
            }

            lcs.Reverse();
            return lcs.ToArray();
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
            string diff = "";

            string lcs = string.Join("", Array.ConvertAll(LongestCommonSubsequence(Array.ConvertAll(before.ToCharArray(), c => (int)c), Array.ConvertAll(after.ToCharArray(), c => (int)c)), i => (char)i));
            Console.WriteLine(lcs);

            int prevOffset = 0, currOffset = 0;

            for (int i = 0; i < lcs.Length; ++i) {

                if (i + prevOffset < before.Length && lcs[i] != before[i + prevOffset]) {
                    diff += "{-";

                    while (i + prevOffset < before.Length && lcs[i] != before[i + prevOffset]) {
                        diff += before[i + prevOffset];
                        ++prevOffset;
                    }

                    diff += "}";
                }

                if (i + currOffset < after.Length && lcs[i] != after[i + currOffset]) {
                    diff += "{+";

                    while (i + currOffset < after.Length && lcs[i] != after[i + currOffset]) {
                        diff += after[i + currOffset];
                        ++currOffset;
                    }

                    diff += "}";
                }

                diff += lcs[i];
            }
            if (lcs.Length == 0) diff += "{-" + before + "}{+" + after + "}";

            return diff;
        }
    }
}
