using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBook.Graphs {
    class Node {
        public List<Node> Links = new List<Node>();
        public int Value = 0;
    }

    class Graph {
        public List<Node> Nodes = new List<Node>();
    }
}
