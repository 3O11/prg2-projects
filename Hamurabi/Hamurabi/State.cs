using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationGame
{
    public class State
    {
        private Dictionary<string, object> data = new Dictionary<string, object>();

        public State()
        {
        }

        public State(Tuple<string, object>[] data)
        {
            foreach (var entry in data)
            {
                this.data[entry.Item1] = entry.Item2;
            }
        }

        public object Get(string name, object defaultValue = null)
        {
            if (!data.ContainsKey(name)) return defaultValue;
            return data[name];
        }

        public int GetInt(string name, int defaultValue = 0)
        {
            if (!data.ContainsKey(name)) return defaultValue;
            return (int)data[name];
        }

        public double GetDouble(string name, double defaultValue = 0)
        {
            if (!data.ContainsKey(name)) return defaultValue;
            return (double)data[name];
        }

        public void Set(string name, object value)
        {
            data[name] = value;
        }

        public State Clone()
        {
            State result = new State();
            foreach (string key in data.Keys)
            {
                result.data[key] = data[key];
            }
            return result;
        }

    }
}
