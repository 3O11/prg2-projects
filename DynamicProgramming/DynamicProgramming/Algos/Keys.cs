using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming {
    class Keys {
        public static int CountPossibleKeys(int grooveCount, int grooveDepthCount) {
            // We don't need to keep the entire 2D array, two columns are sufficient
            int[] prevRow = new int[grooveDepthCount];
            int[] currRow = new int[grooveDepthCount];

            // Set initial values
            for (int i = 0; i < grooveDepthCount; ++i) prevRow[i] = 1;

            for (int i = 1; i < grooveCount; ++i) {
                for (int j = 0; j < grooveDepthCount; ++j) {
                    currRow[j] += j - 1 >= 0 ? prevRow[j - 1] : 0;
                    currRow[j] += prevRow[j];
                    currRow[j] += j + 1 < grooveDepthCount ? prevRow[j + 1] : 0;
                }

                prevRow = currRow;
                currRow = new int[grooveDepthCount];
            }

            int result = 0;
            for (int i = 0; i < grooveDepthCount; ++i) result += prevRow[i];

            return result;
        }
    }
}
