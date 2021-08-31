using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacRow
{
    /// <summary>
    /// AI Player is always run in its own thread with its own copy of the Board.
    /// </summary>
    public class AIPlayer
    {
        private static Random random = new Random();

        /// <summary>
        /// Initialized as a copy of the board that is visualized.
        /// </summary>
        private Board board;

        public AIPlayer(Board board)
        {
            this.board = board;
        }

        /// <summary>
        /// AI method, return your move, i.e. a column to play in, an integer 0..7.
        /// </summary>
        /// <param name="player">Whether you are white or black</param>
        /// <returns>Column to place the stone at, range: 0..7</returns>
        public int PlayAs(bool player)
        {
            // 1) SEARCH FOR THE BEST MOVE
            //      ... use method board.Play(col) to place a move
            //      ... use method board.Reverse(col) to reverse a move 
            // 2) RETURN THE BEST MOVE
            
            // so far, we have a random player implemented in here
            return random.Next(8);
        }
    }
}
