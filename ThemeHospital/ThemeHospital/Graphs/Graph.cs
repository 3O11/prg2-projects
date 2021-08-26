using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThemeHospital.Graphs.Algo;

namespace ThemeHospital {
    class Graph {
        public Graph() {
            _nodes = new List<Node>();
            _nodeIdToIndex = new Dictionary<int, int>();
        }

        public Node GetOrAddNode(NodeType type, int id) {
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
            return _nodes[_nodeIdToIndex[from.GetId()]].AddLink(to, cost);
        }

        public Link AddUndirLink(Node from, Node to, int cost) {
            AddDirLink(to, from, cost);
            return AddDirLink(from, to, cost);
        }

        public List<Node> GetNodes(NodeType type) {
            List<Node> nodes = new List<Node>();
            foreach (Node node in _nodes) if (node.GetType() == type) nodes.Add(node);
            return nodes;
        }

        public Path GetPath(Node from, NodeType to) {
            Dijkstra dijkstra = new Dijkstra(from, to);
            return dijkstra.Crawl();
        }



        List<Node> _nodes;
        Dictionary<int, int> _nodeIdToIndex;
    }
}
