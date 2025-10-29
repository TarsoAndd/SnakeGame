namespace SnakeFinal
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            pbCanvas = new PictureBox();
            lblScore = new Label();
            lblGameOver = new Label();
            gameTimer = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)pbCanvas).BeginInit();
            SuspendLayout();
            // 
            // pbCanvas
            // 
            pbCanvas.BackColor = Color.Black;
            pbCanvas.Location = new Point(202, 38);
            pbCanvas.Name = "pbCanvas";
            pbCanvas.Size = new Size(432, 432);
            pbCanvas.TabIndex = 0;
            pbCanvas.TabStop = false;
            pbCanvas.Click += pbCanvas_Click;
            pbCanvas.Paint += pbCanvas_Paint;
            // 
            // lblScore
            // 
            lblScore.AutoSize = true;
            lblScore.Font = new Font("Minecraft", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblScore.Location = new Point(12, 12);
            lblScore.Name = "lblScore";
            lblScore.Size = new Size(102, 19);
            lblScore.TabIndex = 1;
            lblScore.Text = "Score : 0";
            lblScore.Click += lblScore_Click;
            // 
            // lblGameOver
            // 
            lblGameOver.AutoSize = true;
            lblGameOver.BackColor = Color.Transparent;
            lblGameOver.Font = new Font("Minecraft", 26.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblGameOver.ForeColor = Color.DarkRed;
            lblGameOver.Location = new Point(43, 177);
            lblGameOver.Name = "lblGameOver";
            lblGameOver.Size = new Size(0, 35);
            lblGameOver.TabIndex = 2;
            lblGameOver.TextAlign = ContentAlignment.MiddleCenter;
            lblGameOver.Click += lblGameOver_Click;
            // 
            // gameTimer
            // 
            gameTimer.Tick += UpdateScreen;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(128, 128, 255);
            ClientSize = new Size(825, 509);
            Controls.Add(lblGameOver);
            Controls.Add(lblScore);
            Controls.Add(pbCanvas);
            KeyPreview = true;
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            KeyDown += Form1_KeyDown;
            KeyUp += d;
            ((System.ComponentModel.ISupportInitialize)pbCanvas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pbCanvas;
        private Label lblScore;
        private Label lblGameOver;
        private System.Windows.Forms.Timer gameTimer;
    }
}
