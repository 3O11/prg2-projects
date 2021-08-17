using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationGame
{
    public class Game
    {
        public static Random rnd = new Random();

        private Beat start;
        private Dictionary<Beat, List<Transition>> transitions = new Dictionary<Beat, List<Transition>>();
        private State initial;

        private Beat current;
        private State state;

        public void Play()
        {
            Reset();

            while (current != null)
            {
                current.Run(state);

                Beat next = null;
                if (transitions.ContainsKey(current))
                {
                    foreach (Transition transition in transitions[current])
                    {
                        if (transition.Triggers(state))
                        {
                            next = transition.To;
                            break;
                        }
                    }
                }
                current = next;
            }

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("\n---/ GAME END /---\n");
            Console.ReadLine();
        }

        public void Reset()
        {
            current = start;
            state = initial.Clone();
        }

        public void Add(Transition transition)
        {
            if (!transitions.ContainsKey(transition.From)) transitions[transition.From] = new List<Transition>();
            transitions[transition.From].Add(transition);
        }

        public void SetStart(Beat beat)
        {
            start = beat;
        }

        public void SetInitial(State state)
        {
            initial = state;
        }
    }
}
