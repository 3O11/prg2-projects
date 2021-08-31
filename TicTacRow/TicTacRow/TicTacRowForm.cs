using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacRow
{
    public partial class TicTacRowForm : Form
    {
        public const int ROWS = Board.ROWS;
        public const int COLS = Board.COLS;
        public const int WIN_IN = Board.WIN_COUNT;

        public const int DIAMETER = 30;
        public const int SPACING = 6;

        public Brush WHITE_BRUSH = new SolidBrush(Color.White);
        public Brush BLACK_BRUSH = new SolidBrush(Color.Black);
        public Brush EMPTY_BRUSH = new SolidBrush(Color.Gray);

        public Brush VICTORY_BRUSH = new SolidBrush(Color.Red);
        public Pen VICTORY_PEN;

        Bitmap canvas = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);

        Graphics g;

        Board board;

        Button[,] buttons;

        bool currentPlayer;

        bool vsAI;

        Thread aiThread;

        public TicTacRowForm()
        {
            VICTORY_PEN = new Pen(VICTORY_BRUSH, 4);

            g = Graphics.FromImage(canvas);

            InitializeComponent();

            myCanvas.Image = canvas;

            board = new TicTacRow.Board();

            Reset(false);
        }        

        private void button2_Click(object sender, EventArgs e)
        {
            Reset(false);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Reset(true);
        }

        private void Reset(bool vsAI)
        {
            if (aiThread != null)
            {
                aiThread.Abort();
                aiThread = null;
            }
            board.Reset();
            currentPlayer = Board.WHITE;
            lblWinner.Visible = false;
            lblToPlay.Visible = true;
            this.vsAI = vsAI;
            SetToPlay();
            DrawBoard();
        }

        private void btnRedraw_Click(object sender, EventArgs e)
        {
            DrawBoard();
        }

        private void DrawBoard()
        {
            g.Clear(Color.Blue);

            int radius = DIAMETER;

            int spacing = SPACING;

            for (int row = 0; row < ROWS; ++row)
            {
                for (int col = 0; col < COLS; ++col)
                {
                    Rectangle rect = new Rectangle(spacing + spacing * col + radius * col, spacing + spacing * row + radius * row, radius, radius);
                    Brush target;

                    int boardRow = ROWS - 1 - row;

                    if (board.IsEmpty(boardRow, col))
                    {
                        target = EMPTY_BRUSH;
                    } else
                    if (board.IsBlack(boardRow, col))
                    {
                        target = BLACK_BRUSH;
                    } else
                    {
                        target = WHITE_BRUSH;
                    }

                    g.FillEllipse(target, rect);
                }
            }

            if (board.IsWinner()) {
                VictoryInfo info = board.VictoryInfo;
                g.DrawLine(VICTORY_PEN,
                            4 + spacing / 2 + radius / 2 + spacing * info.ColStart + radius * info.ColStart,
                           -2 + spacing / 2 - radius / 2 + spacing * (ROWS - info.RowStart) + radius * (ROWS - info.RowStart),
                            4 + spacing / 2 + radius / 2 + spacing * info.ColStart + radius * info.ColStart + (spacing + radius) * (WIN_IN-1) * info.ColDir,
                           -2 + spacing / 2 - radius / 2 + spacing * (ROWS - info.RowStart) + radius * (ROWS - info.RowStart) + (spacing + radius) * (WIN_IN-1) * -info.RowDir
                );
            }

            this.Refresh();
        }

        private void PlayInColumn(int col)
        {
            if (board.IsWinner()) return;
            if (!board.MayPlayInCol(col)) return;
            board.Play(col, currentPlayer);
            currentPlayer = !currentPlayer;
            DrawBoard();
            if (board.IsDraw())
            {
                lblToPlay.Text = "DRAW!";
                btnPlayC1.Enabled = btnPlayC2.Enabled = btnPlayC3.Enabled = btnPlayC4.Enabled = btnPlayC5.Enabled = btnPlayC6.Enabled = btnPlayC7.Enabled = btnPlayC8.Enabled = false;
            } else
            if (board.IsWinner())
            {
                lblWinner.Visible = true;
                lblToPlay.Text = board.VictoryInfo.Winner == Board.WHITE ? "WHITE VICTORY!" : "BLACK VICTORY!";
                btnPlayC1.Enabled = btnPlayC2.Enabled = btnPlayC3.Enabled = btnPlayC4.Enabled = btnPlayC5.Enabled = btnPlayC6.Enabled = btnPlayC7.Enabled = btnPlayC8.Enabled = false;
            } else
            {
                SetToPlay();
                if (currentPlayer == Board.BLACK && vsAI)
                {
                    // RUN AI WITHIN OWN THREAD!
                    aiThread = new Thread(() =>
                    {
                        Thread.CurrentThread.IsBackground = true;
                        Board boardCopy = board.Clone();
                        AIPlayer ai = new AIPlayer(boardCopy);
                        int column = ai.PlayAs(currentPlayer);
                        myCanvas.Invoke(
                            (MethodInvoker)(() => PlayInColumn(column))
                        );
                        BoardPool.Back(boardCopy);
                    });
                    aiThread.Start();
                }
            }
        }

        private void btnPlayC1_Click(object sender, EventArgs e)
        {
            if (currentPlayer == Board.BLACK && vsAI) return;
            PlayInColumn(0);
        }

        private void btnPlayC2_Click(object sender, EventArgs e)
        {
            if (currentPlayer == Board.BLACK && vsAI) return;
            PlayInColumn(1);
        }

        private void btnPlayC3_Click(object sender, EventArgs e)
        {
            if (currentPlayer == Board.BLACK && vsAI) return;
            PlayInColumn(2);
        }

        private void btnPlayC4_Click(object sender, EventArgs e)
        {
            if (currentPlayer == Board.BLACK && vsAI) return;
            PlayInColumn(3);
        }

        private void playC5_Click(object sender, EventArgs e)
        {
            if (currentPlayer == Board.BLACK && vsAI) return;
            PlayInColumn(4);
        }

        private void btnPlayC6_Click(object sender, EventArgs e)
        {
            if (currentPlayer == Board.BLACK && vsAI) return;
            PlayInColumn(5);
        }

        private void btnPlayC7_Click(object sender, EventArgs e)
        {
            if (currentPlayer == Board.BLACK && vsAI) return;
            PlayInColumn(6);
        }

        private void btnPlayC8_Click(object sender, EventArgs e)
        {
            if (currentPlayer == Board.BLACK && vsAI) return;
            PlayInColumn(7);
        }

        private void SetToPlay()
        {
            btnPlayC1.Enabled = btnPlayC2.Enabled = btnPlayC3.Enabled = btnPlayC4.Enabled = btnPlayC5.Enabled = btnPlayC6.Enabled = btnPlayC7.Enabled = btnPlayC8.Enabled = true;
            if (currentPlayer)
            {
                lblToPlay.Text = "To Play: WHITE (player)";
            }
            else
            {
                if (vsAI) { 
                    lblToPlay.Text = "To Play: BLACK (computer)";                    
                } else
                {
                    lblToPlay.Text = "To Play: BLACK (player)";
                }
            }
        }

        private void lblWinner_Click(object sender, EventArgs e)
        {

        }

        private void lblToPlay_Click(object sender, EventArgs e)
        {

        }

        
    }
}
