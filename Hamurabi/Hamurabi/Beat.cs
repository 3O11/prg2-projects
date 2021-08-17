using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationGame
{
    public class Beat
    {
        private FText text; // may be null!
        private Input input; // may be null!
        private Effect[] effects; // may be null!

        public Beat(FText text)
        {
            this.text = text;
        }

        public Beat(Input input, params Effect[] effects) : this(null, input, effects)
        {
        }

        public Beat(params Effect[] effects) : this(null, null, effects)
        {
        }

        public Beat(FText text, params Effect[] effects) : this(text, null, effects)
        {
        }

        public Beat(FText text, Input input, params Effect[] effects)
        {
            this.text = text;
            this.input = input;
            this.effects = effects;
        }

        public void Run(State state)
        {
            // TODO: implement me!
            //       1. print text
            //       2. gather input
            //       3. perform all effects

            if (text != null) text.Display(state);
            if (input != null) input.Prompt(state);
            if (effects != null) foreach (var effect in effects) effect.Perform(state);
        }

    }
}
