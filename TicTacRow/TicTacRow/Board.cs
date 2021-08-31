using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacRow
{

    public class Board
    {
        public const bool WHITE = true;
        public const bool BLACK = false;

        /// <summary>
        /// How many columns the board has?
        /// </summary>
        public const int COLS = 8;

        /// <summary>
        /// How many rows the board has?
        /// </summary>
        public const int ROWS = 8;

        /// <summary>
        /// How many stones can be played at maximum.
        /// </summary>
        public const int MAX_STONES = COLS * ROWS;

        /// <summary>
        /// How many stones do we need consecutively to win in this baord?
        /// </summary>
        public const int WIN_COUNT = 4;

        /// <summary>
        /// All directions stored as
        /// [direction type][0 == going left, 1 == going right][0 == delta row, 1 == delta col]
        /// </summary>
        public static readonly int[][][] DIRS =
            new int[][][]   // [0] == HORIZONTAL -, [1] == VERTICAL |, [2] == DIAGONAL \, [3] == DIAGONAL /
            {
                new int[][] // HORIZONTAL -
                {
                    new int[] {  0, -1 },
                    new int[] {  0,  1 }
                },
                new int[][] // VERTICAL   |
                {
                    new int[] { -1,  0 },
                    new int[] {  1,  0 }
                },
                new int[][] // DIAGONAL   \
                {
                    new int[] {  1, -1 },
                    new int[] { -1,  1 }
                },
                new int[][] // DIAGONAL   /
                {
                    new int[] { -1, -1 },
                    new int[] {  1,  1 }
                },
            };

        /// <summary>
        /// Representation of the board [row,col] wise.
        /// We're filling the board as if it is up-side down!
        /// That is: Area[0,0] is left-bottom cell within the visualization
        ///          [0] is bottom row within the visualization
        ///          [BoardRows-1] is top row within the visualization
        /// 
        /// DO NOT MANIPULATE FROM THE OUTSIDE!
        /// </summary>
        public bool?[,] Area { get; private set; }

        /// <summary>
        /// How many stones are in the particular column?
        /// 
        /// DO NOT MANIPULATE FROM THE OUTSIDE!
        /// </summary>
        public int[] Columns { get; private set; }

        /// <summary>
        /// How many stones have been played so far.
        /// </summary>
        public int NumStones { get; private set; }

        /// <summary>
        /// If not-null, the victory condition of the game has been met by one of players.
        /// </summary>
        public VictoryInfo VictoryInfo { get; private set; }

        /// <summary>
        /// Empty board.
        /// </summary>
        public Board()
        {
            Reset();
        }

        /// <summary>
        /// Copies values from 'source' into the 'target'.
        /// ASSUMING 'target' TO BE RESET TO THE SAME DIMENSIONS AS 'source'.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="target"></param>
        public static void Copy(Board source, Board target)
        {
            for (int row = 0; row < ROWS; ++row)
            {
                for (int col = 0; col < COLS; ++col)
                {
                    target.Area[row, col] = source.Area[row, col];
                }
            }
            for (int i = 0; i < COLS; ++i)
            {
                target.Columns[i] = source.Columns[i];
            }
            target.NumStones = source.NumStones;
            target.VictoryInfo = source.VictoryInfo; // shallow copy
        }

        /// <summary>
        /// Returns new instance of the Board with values cloned from this one.
        /// </summary>
        /// <returns></returns>
        public Board Clone()
        {
            return BoardPool.GetCopy(this);
        }

        /// <summary>
        /// Wipes the board, (re)instantiate Area and Columns
        /// </summary>
        public void Reset()
        {
            Area = new bool?[ROWS, COLS];
            Columns = new int[COLS];
            for (int i = 0; i < COLS; ++i)
            {
                Columns[i] = 0;
            }
            NumStones = 0;
            VictoryInfo = null;
        }

        /// <summary>
        /// Whether a 'player' stone is at [row,col].
        /// </summary>
        /// <param name="player"></param>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <returns></returns>
        public bool IsPlayer(bool player, int row, int col)
        {
            return Area[row, col] == player;
        }

        /// <summary>
        /// Whether there is WHITE stone at [row,col].
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <returns></returns>
        public bool IsWhite(int row, int col)
        {
            return Area[row,col] == WHITE;
        }

        /// <summary>
        /// Whether there is BLACK stone at [row,col].
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <returns></returns>
        public bool IsBlack(int row, int col)
        {
            return Area[row, col] == BLACK;
        }

        /// <summary>
        /// Whether [row,col] is empty.
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <returns></returns>
        public bool IsEmpty(int row, int col)
        {
            return Area[row, col] == null;
        }

        /// <summary>
        /// Whether a play can be made into column of index 'col'.
        /// </summary>
        /// <param name="col"></param>
        /// <returns></returns>
        public bool MayPlayInCol(int col)
        {
            return Columns[col] < ROWS;
        }

        /// <summary>
        /// Performs the move by 'player' into the column of index [col] affecting THIS board.       
        /// Perfoms the victory condition check for the move.
        /// </summary>
        /// <param name="col"></param>
        /// <param name="player"></param>
        public void Play(int col, bool player)
        {
            if (IsWinner()) return;
            Area[Columns[col], col] = player;            
            CheckWin(Columns[col], col);
            NumStones += 1;
            Columns[col] += 1;
        }

        /// <summary>
        /// Reverse the last move made within the column [col].
        /// </summary>
        /// <param name="col"></param>
        public void Reverse(int col)
        {
            if (Columns[col] == 0) return;
            Area[Columns[col] - 1, col] = null;
            NumStones -= 1;
            Columns[col] -= 1;
            VictoryInfo = null;
        }

        private bool CheckWin(int row, int col)
        {
            bool? mayBePlayer = Area[row, col];
            if (mayBePlayer == null) return false;
            bool player = AsPlayer(mayBePlayer);
            int count;
            int scan1, scan2;

            foreach (int[][] dir in DIRS)
            {
                scan1 = Scan(player, row, col, dir[0][0], dir[0][1]);
                scan2 = Scan(player, row, col, dir[1][0], dir[1][1]);
                count = scan1 + scan2 - 1; // position [row,col] is counted twice
                if (count >= WIN_COUNT)
                {
                    Victory(player, row + (scan1-1) * dir[0][0], col + (scan1-1) * dir[0][1], -dir[0][0], -dir[0][1], WIN_COUNT);
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Returns how many stones of "player" is beginning at the point [row,col] in the direction [dx,dy].
        /// </summary>
        /// <param name="player"></param>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="dRow">delta-row</param>
        /// <param name="dCol">delta-col</param>
        /// <returns></returns>
        public int Scan(bool? player, int row, int col, int dRow, int dCol)
        {
            int count = 0;
            while (true)
            {
                if (row < 0) return count;
                if (row >= ROWS) return count;
                if (col < 0) return count;
                if (col >= COLS) return count;
                if (Area[row, col] != player) return count;
                count += 1;
                row += dRow;
                col += dCol;
            }
            return count;
        }

        private void Victory(bool player, int rowStart, int colStart, int rowDir, int colDir, int winCount)
        {
            VictoryInfo = new VictoryInfo(player, rowStart, colStart, rowDir, colDir);
        }

        /// <summary>
        /// TRUE if no more stone can be played, all columns are full, and there is NO victory.
        /// </summary>
        /// <returns></returns>
        public bool IsDraw()
        {            
            return NumStones >= MAX_STONES;
        }

        /// <summary>
        /// TRUE is some player satisfies a victory condition (has 4 in row/column/diagonal).
        /// Check GetWinner() or VictoryInfo.Winner for information who has won.
        /// </summary>
        /// <returns></returns>
        public bool IsWinner()
        {
            return VictoryInfo != null;
        }

        /// <summary>
        /// Checks whether 'players' has won on the board.
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public bool IsWinner(bool player)
        {
            return IsWinner() && VictoryInfo.Winner == player;
        }

        /// <summary>
        /// Returns a winner player or throws an exception.
        /// </summary>
        /// <returns></returns>
        public bool GetWinner()
        {
            if (VictoryInfo == null)
            {
                throw new Exception("There is no winner yet!");
            }
            return VictoryInfo.Winner;            
        }

        public bool AsPlayer(bool? plr)
        {
            if (plr == true) return true;
            if (plr == false) return false;
            throw new Exception("plr == null, NO PLAYER!");
        }

    }

    public class BoardPool
    {
        private static Queue<Board> pool = new Queue<Board>();

        public static Board Get()
        {
            if (pool.Count == 0) return new Board();
            return pool.Dequeue();
        }

        public static Board GetCopy(Board source)
        {
            Board result;
            if (pool.Count == 0) result = new Board();
            else result = pool.Dequeue();
            Board.Copy(source, result);
            return result;
        }

        public static void Back(Board board)
        {
            pool.Enqueue(board);

        }
    }

}
