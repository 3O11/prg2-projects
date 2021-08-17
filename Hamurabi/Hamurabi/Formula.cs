using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationGame
{
    public class Formula
    {
        private Func<State, Random, object> func;

        public Formula(Func<State, Random, object> formula)
        {
            func = formula;
        }

        public object Eval(State s, Random rnd)
        {
            return func(s, rnd);
        }
    }
}
