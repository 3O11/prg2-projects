using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator {
    class ConsoleSource : ISource {
        public bool HasNext() {
            buffer = Console.ReadLine();

            if (buffer == "" || buffer == "end") return false;
            return true;
        }

        public string GetLine() {
            return buffer;
        }

        string buffer;
    }
}
