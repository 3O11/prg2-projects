using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace RaycastingEngine {
    static class Utils {
        public static Tuple<int,int> ParseDimensions(string dimensions) {
            Regex r = new Regex(@"(?<x>[0-9]+)x(?<y>[0-9]+)");
            Match m = r.Match(dimensions);
            if (m.Success) {
                int x = int.Parse(m.Groups["x"].Value);
                int y = int.Parse(m.Groups["y"].Value);
                return new Tuple<int, int>(x, y);
            }
            else {
                throw new Exception("Invalid Dimensions format!");
            }
        }
    }
}
