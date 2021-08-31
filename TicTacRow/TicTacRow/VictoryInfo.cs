using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacRow
{
    public class VictoryInfo
    {
        /// <summary>
        /// Which player is a winner.
        /// </summary>
        public bool Winner { get; private set; }
        public int RowStart { get; private set; }
        public int ColStart { get; private set; }
        public int RowDir { get; private set; }
        public int ColDir { get; private set; }

        public VictoryInfo(bool winner, int rowStart, int colStart, int rowDir, int colDir)
        {
            this.Winner = winner;
            this.RowStart = rowStart;
            this.ColStart = colStart;
            this.RowDir = rowDir;
            this.ColDir = colDir;
        }
    }
}
