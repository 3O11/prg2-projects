using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator {
    class Times : IOperator {
        public bool CanProcess(string line) {
            string[] input = line.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            if (input[0] != "*") return false;
            if (double.TryParse(input[1], out double a)) return true;
            return false;
        }

        public double Process(double left, string right) {
            string[] input = right.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            double.TryParse(input[1], out double a);

            return left * a;
        }

        public char[] separators = { ' ', '\t', };
    }
}
