using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThemeHospital {
    class Path {
        public Path(List<Link> links) {
            _links = links;
        }

        public List<Link> GetLinks() {
            return _links;
        }

        public int GetCost(int multi) {
            int totalCost = 0;
            foreach (var link in _links) {
                totalCost += link.GetCost();
            }

            return totalCost * multi;
        }

        public Node GetEnd() {
            return _links.Last().GetTo();
        }

        public void AddLinks(List<Link> links) {
            _links.AddRange(links);
        }

        public string ToString() {
            string result = "";

            foreach (var link in _links) result += link.GetFrom().ToString() + " >> ";
            result += _links.Last().GetTo().ToString();

            return result;
        }

        List<Link> _links;
    }
}
