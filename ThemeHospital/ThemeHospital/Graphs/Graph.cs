using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThemeHospital.Graphs {
    class Graph {
        public Graph() {
            _nodes = new List<Node>();
            _nodeIdToIndex = new Dictionary<int, int>();
        }

        public Node GetOrAddNode(int id, NodeType type) {
            if (_nodeIdToIndex.ContainsKey(id)) {
                if (_nodes[_nodeIdToIndex[id]].GetType() != type) Console.WriteLine("The types are mismatched!");

                return _nodes[_nodeIdToIndex[id]];
            }
            else {
                Node newNode = new Node(id, type);
                _nodes.Add(newNode);
                _nodeIdToIndex[id] = _nodes.Count - 1;
                return newNode;
            }
        }

        public Link AddDirLink(Node from, Node to, int cost) {

        }

        public Link AddUndirLink(Node from, Node to, int cost) {
        }

        public List<Node> GetNodes(NodeType type) {

        }

        public Path GetPath(Node from, NodeType to) {
        }


        List<Node> _nodes;
        Dictionary<int, int> _nodeIdToIndex;
    }
}
