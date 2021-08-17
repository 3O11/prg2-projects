using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationGame
{
    public class Transition
    {
        public Beat From { get; private set; }
        public Beat To { get; private set; }

        public Formula Condition { get; private set; }

        public Transition(Beat from, Beat to) : this(from, to, new Formula( (state, rnd) => ( true ) ))
        {            
        }

        public Transition(Beat from, Beat to, Formula condition)
        {
            From = from;
            To = to;
            Condition = condition;
        }

        public bool Triggers(State state)
        {
            return (bool)Condition.Eval(state, Game.rnd);
        }
    }
}
