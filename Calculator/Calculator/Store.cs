using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator {
    class Store : IOperator {
        public Store(Memory mem, bool multiValueMem) {
            memory = mem;
            this.multiValueMem = multiValueMem;
        }

        public bool CanProcess(string line) {
            string[] input = line.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            if (input[0] != "STORE") return false;
            return true;
        }

        public double Process(double left, string right) {
            string[] input = right.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            if (multiValueMem && input.Length > 1) memory.Store(left, input[1]);
            else memory.Store(left);

            return left;
        }

        Memory memory;
        bool multiValueMem;
        public char[] separators = { ' ', '\t', };
    }
}
