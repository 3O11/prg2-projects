using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sierpinsky
{
    public partial class Form1 : Form
    {
        private Color color = Color.Blue;
        private int recursionDepth = 5;

        public Form1()
        {
            InitializeComponent();

            this.ResizeEnd += button2_Click;
            this.Shown += button2_Click;

            numericUpDown1.Value = 5;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog;

            using (colorDialog = new ColorDialog())
            {
                if (colorDialog.ShowDialog() == DialogResult.OK) {
                    this.color = colorDialog.Color;
                }
            }
        }
        
        
        private void button2_Click(object sender, EventArgs e)
        {           
            using (Graphics g = this.CreateGraphics())
            {
                g.Clear(Color.Gray);
                using (Brush triangleBrush = new SolidBrush(color)) 
                {
                    using (Brush backgroundBrush = new SolidBrush(Color.Gray))
                    {
                        drawSierpinsky(g, triangleBrush, backgroundBrush, recursionDepth, ClientSize.Width / 2, 0, 0, ClientSize.Height, ClientSize.Width, ClientSize.Height);
                    }
                }
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown1.Value > 15) numericUpDown1.Value = 15;
            if (numericUpDown1.Value < 1) numericUpDown1.Value = 1;
            recursionDepth = (int)numericUpDown1.Value;
        }

        private void drawSierpinsky(Graphics g, Brush triangleBrush, Brush backgroundBrush, int n, double x1, double y1, double x2, double y2, double x3, double y3)
        {
            Point[] triangle = new Point[] {
                new Point((int)x1, (int)y1),
                new Point((int)x2, (int)y2),
                new Point((int)x3, (int)y3),
            };

            if (n == 1) {
                g.FillPolygon(triangleBrush, triangle);
            }
            else {
                double cx1x2 = (x1 + x2) / 2;
                double cy1y2 = (y1 + y2) / 2;

                double cx1x3 = (x1 + x3) / 2;
                double cy1y3 = (y1 + y3) / 2;

                double cx2x3 = (x2 + x3) / 2;
                double cy2y3 = (y2 + y3) / 2;

                // Top triangle
                drawSierpinsky(g, triangleBrush, backgroundBrush, n - 1, x1, y1, cx1x2, cy1y2, cx1x3, cy1y3);
                // Left triangle
                drawSierpinsky(g, triangleBrush, backgroundBrush, n - 1, cx1x2, cy1y2, x2, y2, cx2x3, cy2y3);
                // Right triangle
                drawSierpinsky(g, triangleBrush, backgroundBrush, n - 1, cx1x3, cy1y3, cx2x3, cy2y3, x3, y3);
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
    }
}
