using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThemeHospital.Graphs {
    class Link {
        public Link(Node from, Node to, int cost) {
            _from = from;
            _to = to;
            _cost = cost;
        }

        public Node GetFrom() {
            return _from;
        }

        public Node GetTo() {
            return _to;
        }

        public int GetCost() {
            return _cost;
        }

        Node _from;
        Node _to;
        int _cost;
    }
}
