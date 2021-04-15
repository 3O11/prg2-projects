using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator {
    class Load : IOperator {
        public Load(Memory mem, bool multiValueMem) {
            memory = mem;
            this.multiValueMem = multiValueMem;
        }

        public bool CanProcess(string line) {
            string[] input = line.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            if (input[0] != "LOAD") return false;
            return true;
        }

        public double Process(double left, string right) {
            string[] input = right.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            double output;

            if (multiValueMem) output = (input.Length >= 2) ? memory.Retrieve(input[1]) : 0.0;
            else output = memory.Retrieve();

            return output;
        }

        Memory memory;
        bool multiValueMem;
        public char[] separators = { ' ', '\t', };
    }
}
