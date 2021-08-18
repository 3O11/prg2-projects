using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBook.Graphs {
    interface IVisitor {
        void Start();
        void Visit(Node visiting, Node from);
        void End();
    }
}
