using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator {
    class Memory {
        public Memory(bool useDictionary) {
            this.useDictionary = useDictionary;
            valueStorage = new Dictionary<string, double>();
            valueStorage.Add("default", 0.0);
        }

        public void Store(double value, string valName = "default") {
            if(useDictionary) {
                if (valueStorage.ContainsKey(valName)) valueStorage[valName] = value;
                else valueStorage.Add(valName, value);
            }
            else {
                valueStorage["default"] = value;
            }
        }

        public double Retrieve(string valName = "default") {
            if (useDictionary && valueStorage.ContainsKey(valName)) return valueStorage[valName];
            else return valueStorage["default"];
        }

        Dictionary<string, double> valueStorage;
        bool useDictionary;
    }
}
