using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThemeHospital.Graphs {
    class Node {
        public Node(int id, NodeType type) {
            _links = new List<Link>();
            _id = id;
            _type = type;
        }

        public List<Link> GetLinks() {
            return _links;
        }

        public NodeType GetType() {
            return _type;
        }

        public int GetId() {
            return _id;
        }

        public Link AddLink(Node to, int cost) {
            Link newLink = new Link(this, to, cost);
            _links.Add(newLink);
            return newLink;
        }

        List<Link> _links;
        NodeType _type;
        int _id;
    }
}
