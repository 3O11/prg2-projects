using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationGame
{
    public class Input
    {
        private Formula min;
        private Formula max;
        private FText prompt;
        private string variable;

        public Input(FText prompt, Formula min, Formula max) : this(prompt, "input", min, max)
        {
        }

        public Input(FText prompt, string variable, Formula min, Formula max)
        {
            this.min = min;
            this.max = max;
            this.prompt = prompt;
            this.variable = variable;
        }

        public void Prompt(State state)
        {            
            int minValue = (int)min.Eval(state, Game.rnd);
            int maxValue = (int)max.Eval(state, Game.rnd);
            // TODO: implement me!
            //       1. you need to read integer from console
            //       2. integer must be from range [minValue;maxValue] (extremes included)
            //       3. then you have to save that input into 'state' under name 'variable'
            bool valid = false;
            while (!valid) {
                prompt.Display(state);
                Console.Write($"(Min: {minValue} .. Max: {maxValue}): ");
                string input = Console.ReadLine();
                int nextValue;
                int.TryParse(input, out nextValue);

                if (minValue <= nextValue && nextValue <= maxValue) {
                    state.Set(variable, nextValue);
                    valid = true;
                }
                else {
                    Console.WriteLine("Value is out of the valid range.");
                }
            }

            
        }
    }
}
