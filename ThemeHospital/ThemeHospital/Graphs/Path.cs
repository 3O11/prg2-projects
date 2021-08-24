using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThemeHospital.Graphs {
    class Path {
        public Path() {
            _links = new List<Link>();
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

        List<Link> _links;
    }
}
