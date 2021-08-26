using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThemeHospital {
    enum HealthProblem {
        NEUROTIC,
        PNEUMONIA,
        HIP_PAIN,
        CARDIAC,
    }

    static class HealthProblemUtils {
        public static HealthProblem GetHealthProblem(int value) {
            if (Enum.IsDefined(typeof(HealthProblem), value)) {
                return (HealthProblem)value;
            }
            throw new Exception("No HealthProblem for: " + value);
        }

        public static HealthProblem GetHealthProblem(string name) {
            return (HealthProblem)Enum.Parse(typeof(HealthProblem), name);
        }

        public static int AsInt(HealthProblem hp) {
            return (int)hp;
        }
    }
}
