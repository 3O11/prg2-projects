using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBook
{
    class Option
    {
        public Option(string text, int pageNum) {
            this.text = text;
            this.pageNum = pageNum;
        }

        public string text;
        public int pageNum;
    }
}
