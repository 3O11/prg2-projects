using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThemeHospital.Graphs {
    namespace Algo {
        class Dijkstra {
            public Dijkstra(Node from, NodeType to) {
                _toType = to;

                _openList = new OpenList();
                _closedList = new HashSet<Node>();
                _pathCost = new Dictionary<Node, int>();
                _pathParent = new Dictionary<Node, Node>();

                _openList.Enqueue(from, 0);
                _pathCost[from] = 0;
                _pathParent[from] = null;
            }

            public Path Crawl() {
                while (_openList.Count > 0) {
                    Node node = _openList.Dequeue();
                    if (node.GetType() == _toType) {
                        _to = node;
                        return reconstructPath();
                    }
                    Expand(node);
                    _closedList.Add(node);
                }
                return null;
            }

            void Expand(Node probingNode) {
                foreach (var link in probingNode.GetLinks()) {
                    var child = link.GetTo();
                    int newCost = _pathCost[probingNode] + link.GetCost();
                    if (!_pathCost.ContainsKey(child)) {
                        _pathCost[child] = newCost;
                        _pathParent[child] = probingNode;
                        _openList.Enqueue(child, newCost);
                    }
                    else {
                        int oldCost = _pathCost[child];
                        if (newCost < oldCost) {
                            _pathCost[child] = newCost;
                            _pathParent[child] = probingNode;
                            _openList.Update(child, newCost);
                        }
                    }
                }
            }

            Path reconstructPath() {
                List<Link> path = new List<Link>();
                Node traversing = _to;

                while (traversing != null) {
                    if (_pathParent[traversing] == null) break;
                    Node parent = _pathParent[traversing];
                    foreach (var link in parent.GetLinks()) {
                        if (link.GetTo() == traversing) {
                            path.Add(link);
                            traversing = parent;
                            break;
                        }
                    }
                }

                path.Reverse();
                return new Path(path);
            }

            Node _to;
            NodeType _toType;

            OpenList _openList;
            HashSet<Node> _closedList;
            Dictionary<Node, int> _pathCost;
            Dictionary<Node, Node> _pathParent;

            // This class isn't used anywhere else.
            // I think it's better for it to not be visible.
            class OpenList {
                public OpenList() {
                    _data = new SortedSet<Tuple<Node, int>>(
                        Comparer<Tuple<Node, int>>.Create((x, y) => {
                            if (x.Item2 == y.Item2) {
                                return x.Item1.GetId() - y.Item1.GetId();
                            }
                            return x.Item2 - y.Item2;
                        })
                    );
                }

                public void Enqueue(Node node, int value) {
                    _data.Add(new Tuple<Node, int>(node, value));
                }

                public Node Dequeue() {
                    IEnumerator<Tuple<Node, int>> e = _data.GetEnumerator();
                    e.MoveNext();
                    _data.Remove(e.Current);
                    return e.Current.Item1;
                }

                public void Update(Node node, int newValue) {
                    foreach (var tuple in _data) if (tuple.Item1 == node) { _data.Remove(tuple); break; }
                    _data.Add(new Tuple<Node, int>(node, newValue));
                }

                public int Count {
                    get {
                        return _data.Count;
                    }
                }

                SortedSet<Tuple<Node, int>> _data;
            }
        }
    }
}
