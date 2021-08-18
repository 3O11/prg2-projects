using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBook.Graphs {
    class PathStoringVisitor : IVisitor {
        public void Start() {
            terminalNodes = new List<Node>();
        }

        public void Visit(Node visiting, Node from) {
            previous[visiting] = from;
            if (visiting.Links.Count == 0) terminalNodes.Add(visiting);
        }

        public void End() {}

        public List<Node> GetPath(Node terminalNode) {
            List<Node> path = new List<Node>();

            Node current = terminalNode;
            while (current != null) { // previous.ContainsKey(current) <- As long as the algo is correct, I don't need to check this
                path.Add(current);
                current = previous[current];
            }
            path.Reverse();

            return path;
        }

        public List<Node> terminalNodes { get; private set; }
        
        Dictionary<Node, Node> previous = new Dictionary<Node, Node>();
    }
}
