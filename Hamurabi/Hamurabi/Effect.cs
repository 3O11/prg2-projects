using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationGame
{
    public class Effect
    {
        private string variable;
        private Formula value;
        private Formula condition; // may be null!

        public Effect(string variable, Formula formula) : this(variable, formula, null)
        {
        }

        public Effect(string variable, Formula formula, Formula condition)
        {
            this.variable = variable;
            this.value = formula;
            this.condition = condition;
        }

        public void Perform(State s)
        {
            // TODO: implement me!
            //       if condition is null or evaluates to true, set 'value' as 'variable' into 's'

            if (condition == null || (bool)condition.Eval(s, Game.rnd)) s.Set(variable, value.Eval(s, Game.rnd));
        }

    }
}
