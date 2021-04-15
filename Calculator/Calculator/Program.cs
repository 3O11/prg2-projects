using System;

namespace Calculator {
    class Program {
        /// <summary>
        /// Entry point of the program. Operators, source and output have to be prepared here,
        /// the Calculator won't be able to do anything otherwise.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args) {
            bool useMultiValue = false;
            Memory mem = new Memory(useMultiValue);
            Load load = new Load(mem, useMultiValue);
            Store store = new Store(mem, useMultiValue);

            IOperator[] operators = { new Plus(), new Minus(), new Times(), new Divide(), load, store };
            ConsoleOutput output = new ConsoleOutput();
            ConsoleSource source = new ConsoleSource();
            // FileSource source = new FileSource("source.txt");


            Calc calculator = new Calc(operators, source, output);

            calculator.Process();
        }
    }
}
