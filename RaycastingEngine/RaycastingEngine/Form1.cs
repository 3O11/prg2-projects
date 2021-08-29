using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;

namespace RaycastingEngine {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();

            Init();

            _timer = new System.Timers.Timer(1000/60);
            _timer.Elapsed += Update;
            _timer.AutoReset = true;
            _timer.Enabled = true;
        }

        private void Init() {
            _game = Game.Load("test.txt");
        }

        private void Update(object sender, ElapsedEventArgs e) {
            _game.Update();

            using (Graphics g = this.CreateGraphics()) {
                _game.Render(g, Width, Height);
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e) {

        }

        private void Form1_MouseMove(object sender, MouseEventArgs e) {
            
        }

        System.Timers.Timer _timer;
        Game _game;
    }
}
