namespace TicTacRow
{
    partial class TicTacRowForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnReset1 = new System.Windows.Forms.Button();
            this.myCanvas = new System.Windows.Forms.PictureBox();
            this.btnPlayC1 = new System.Windows.Forms.Button();
            this.btnPlayC2 = new System.Windows.Forms.Button();
            this.btnPlayC3 = new System.Windows.Forms.Button();
            this.btnPlayC4 = new System.Windows.Forms.Button();
            this.btnPlayC5 = new System.Windows.Forms.Button();
            this.btnPlayC6 = new System.Windows.Forms.Button();
            this.btnPlayC7 = new System.Windows.Forms.Button();
            this.btnPlayC8 = new System.Windows.Forms.Button();
            this.lblToPlay = new System.Windows.Forms.Label();
            this.lblWinner = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.myCanvas)).BeginInit();
            this.SuspendLayout();
            // 
            // btnReset1
            // 
            this.btnReset1.Location = new System.Drawing.Point(5, 12);
            this.btnReset1.Name = "btnReset1";
            this.btnReset1.Size = new System.Drawing.Size(56, 33);
            this.btnReset1.TabIndex = 1;
            this.btnReset1.Text = "H vs. H";
            this.btnReset1.UseVisualStyleBackColor = true;
            this.btnReset1.Click += new System.EventHandler(this.button2_Click);
            // 
            // myCanvas
            // 
            this.myCanvas.Location = new System.Drawing.Point(-3, 86);
            this.myCanvas.Name = "myCanvas";
            this.myCanvas.Size = new System.Drawing.Size(298, 296);
            this.myCanvas.TabIndex = 3;
            this.myCanvas.TabStop = false;
            // 
            // btnPlayC1
            // 
            this.btnPlayC1.Location = new System.Drawing.Point(5, 60);
            this.btnPlayC1.Name = "btnPlayC1";
            this.btnPlayC1.Size = new System.Drawing.Size(30, 20);
            this.btnPlayC1.TabIndex = 4;
            this.btnPlayC1.Tag = "0";
            this.btnPlayC1.Text = "C1";
            this.btnPlayC1.UseVisualStyleBackColor = true;
            this.btnPlayC1.Click += new System.EventHandler(this.btnPlayC1_Click);
            // 
            // btnPlayC2
            // 
            this.btnPlayC2.Location = new System.Drawing.Point(41, 60);
            this.btnPlayC2.Name = "btnPlayC2";
            this.btnPlayC2.Size = new System.Drawing.Size(30, 20);
            this.btnPlayC2.TabIndex = 5;
            this.btnPlayC2.Tag = "1";
            this.btnPlayC2.Text = "C2";
            this.btnPlayC2.UseVisualStyleBackColor = true;
            this.btnPlayC2.Click += new System.EventHandler(this.btnPlayC2_Click);
            // 
            // btnPlayC3
            // 
            this.btnPlayC3.Location = new System.Drawing.Point(77, 60);
            this.btnPlayC3.Name = "btnPlayC3";
            this.btnPlayC3.Size = new System.Drawing.Size(30, 20);
            this.btnPlayC3.TabIndex = 6;
            this.btnPlayC3.Tag = "2";
            this.btnPlayC3.Text = "C3";
            this.btnPlayC3.UseVisualStyleBackColor = true;
            this.btnPlayC3.Click += new System.EventHandler(this.btnPlayC3_Click);
            // 
            // btnPlayC4
            // 
            this.btnPlayC4.Location = new System.Drawing.Point(113, 60);
            this.btnPlayC4.Name = "btnPlayC4";
            this.btnPlayC4.Size = new System.Drawing.Size(30, 20);
            this.btnPlayC4.TabIndex = 7;
            this.btnPlayC4.Tag = "3";
            this.btnPlayC4.Text = "C4";
            this.btnPlayC4.UseVisualStyleBackColor = true;
            this.btnPlayC4.Click += new System.EventHandler(this.btnPlayC4_Click);
            // 
            // btnPlayC5
            // 
            this.btnPlayC5.Location = new System.Drawing.Point(149, 60);
            this.btnPlayC5.Name = "btnPlayC5";
            this.btnPlayC5.Size = new System.Drawing.Size(30, 20);
            this.btnPlayC5.TabIndex = 8;
            this.btnPlayC5.Tag = "4";
            this.btnPlayC5.Text = "C5";
            this.btnPlayC5.UseVisualStyleBackColor = true;
            this.btnPlayC5.Click += new System.EventHandler(this.playC5_Click);
            // 
            // btnPlayC6
            // 
            this.btnPlayC6.Location = new System.Drawing.Point(185, 60);
            this.btnPlayC6.Name = "btnPlayC6";
            this.btnPlayC6.Size = new System.Drawing.Size(30, 20);
            this.btnPlayC6.TabIndex = 9;
            this.btnPlayC6.Tag = "5";
            this.btnPlayC6.Text = "C6";
            this.btnPlayC6.UseVisualStyleBackColor = true;
            this.btnPlayC6.Click += new System.EventHandler(this.btnPlayC6_Click);
            // 
            // btnPlayC7
            // 
            this.btnPlayC7.Location = new System.Drawing.Point(221, 60);
            this.btnPlayC7.Name = "btnPlayC7";
            this.btnPlayC7.Size = new System.Drawing.Size(30, 20);
            this.btnPlayC7.TabIndex = 10;
            this.btnPlayC7.Tag = "6";
            this.btnPlayC7.Text = "C7";
            this.btnPlayC7.UseVisualStyleBackColor = true;
            this.btnPlayC7.Click += new System.EventHandler(this.btnPlayC7_Click);
            // 
            // btnPlayC8
            // 
            this.btnPlayC8.Location = new System.Drawing.Point(257, 60);
            this.btnPlayC8.Name = "btnPlayC8";
            this.btnPlayC8.Size = new System.Drawing.Size(30, 20);
            this.btnPlayC8.TabIndex = 11;
            this.btnPlayC8.Tag = "7";
            this.btnPlayC8.Text = "C8";
            this.btnPlayC8.UseVisualStyleBackColor = true;
            this.btnPlayC8.Click += new System.EventHandler(this.btnPlayC8_Click);
            // 
            // lblToPlay
            // 
            this.lblToPlay.AutoSize = true;
            this.lblToPlay.Location = new System.Drawing.Point(134, 12);
            this.lblToPlay.Name = "lblToPlay";
            this.lblToPlay.Size = new System.Drawing.Size(45, 13);
            this.lblToPlay.TabIndex = 12;
            this.lblToPlay.Text = "To play:";
            this.lblToPlay.Click += new System.EventHandler(this.lblToPlay_Click);
            // 
            // lblWinner
            // 
            this.lblWinner.AutoSize = true;
            this.lblWinner.Location = new System.Drawing.Point(134, 32);
            this.lblWinner.Name = "lblWinner";
            this.lblWinner.Size = new System.Drawing.Size(97, 13);
            this.lblWinner.TabIndex = 13;
            this.lblWinner.Text = "We have a winner!";
            this.lblWinner.Visible = false;
            this.lblWinner.Click += new System.EventHandler(this.lblWinner_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(67, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(59, 33);
            this.button1.TabIndex = 14;
            this.button1.Text = "H vs. AI";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // TicTacRowForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(291, 380);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblWinner);
            this.Controls.Add(this.lblToPlay);
            this.Controls.Add(this.btnPlayC8);
            this.Controls.Add(this.btnPlayC7);
            this.Controls.Add(this.btnPlayC6);
            this.Controls.Add(this.btnPlayC5);
            this.Controls.Add(this.btnPlayC4);
            this.Controls.Add(this.btnPlayC3);
            this.Controls.Add(this.btnPlayC2);
            this.Controls.Add(this.btnPlayC1);
            this.Controls.Add(this.btnReset1);
            this.Controls.Add(this.myCanvas);
            this.Name = "TicTacRowForm";
            this.Text = "TicTacRow";
            ((System.ComponentModel.ISupportInitialize)(this.myCanvas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnReset1;
        private System.Windows.Forms.PictureBox myCanvas;
        private System.Windows.Forms.Button btnPlayC1;
        private System.Windows.Forms.Button btnPlayC2;
        private System.Windows.Forms.Button btnPlayC3;
        private System.Windows.Forms.Button btnPlayC4;
        private System.Windows.Forms.Button btnPlayC5;
        private System.Windows.Forms.Button btnPlayC6;
        private System.Windows.Forms.Button btnPlayC7;
        private System.Windows.Forms.Button btnPlayC8;
        private System.Windows.Forms.Label lblToPlay;
        private System.Windows.Forms.Label lblWinner;
        private System.Windows.Forms.Button button1;
    }
}

