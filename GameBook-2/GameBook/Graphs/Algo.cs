using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBook.Graphs {
    namespace Algo {
        static class DFS {
            public static void Crawl(Node startNode, IVisitor visitor) {
                Stack<Node> q = new Stack<Node>();
                HashSet<Node> vis = new HashSet<Node>();
                visitor.Start();

                q.Push(startNode);
                vis.Add(startNode);
                visitor.Visit(startNode, null);

                while(q.Count > 0) {
                    Node current = q.Pop();
                    foreach (Node next in current.Links) {
                        if (vis.Contains(next)) continue;
                        q.Push(next);
                        vis.Add(next);
                        visitor.Visit(next, current);
                    }
                }

                visitor.End();
            }
        }

        static class BFS {
            public static void Crawl(Node startNode, IVisitor visitor) {
                Queue<Node> q = new Queue<Node>();
                HashSet<Node> vis = new HashSet<Node>();
                visitor.Start();

                q.Enqueue(startNode);
                vis.Add(startNode);
                visitor.Visit(startNode, null);

                while (q.Count > 0) {
                    Node current = q.Dequeue();
                    foreach (Node next in current.Links) {
                        if (vis.Contains(next)) continue;
                        q.Enqueue(next);
                        vis.Add(next);
                        visitor.Visit(next, current);
                    }
                }

                visitor.End();
            }
        }
    }
}
