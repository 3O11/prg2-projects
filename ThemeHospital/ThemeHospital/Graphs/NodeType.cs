using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThemeHospital {
    enum NodeType {
        ENTRANCE,
        INFODESK,
        GP,
        EEG,
        SONO,
        XRAY,
        PSYCHO,
        TREATMENT,
    }

    static class NodeTypeUtils {
        public static NodeType GetNodeType(int value) {
            if (Enum.IsDefined(typeof(NodeType), value)) {
                return (NodeType)value;
            }
            throw new Exception("No NodeType for: " + value);
        }

        public static NodeType GetNodeType(string name) {
            return (NodeType)Enum.Parse(typeof(NodeType), name);
        }

        public static int AsInt(NodeType nt) {
            return (int)nt;
        }
    }
}
