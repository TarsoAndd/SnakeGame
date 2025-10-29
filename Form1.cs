using System;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;

namespace SnakeFinal 
{
    public partial class Form1 : Form
    {
        private Game _snakeGame;
        private PrivateFontCollection pfc = new PrivateFontCollection();

        public Form1()
        {
            InitializeComponent();
            _snakeGame = new Game(pbCanvas.Width, pbCanvas.Height);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            gameTimer.Interval = 1000 / Settings.Speed;
            gameTimer.Tick += UpdateScreen;
            gameTimer.Start();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left when Settings.CurrentDirection != Direction.Right:
                    Settings.CurrentDirection = Direction.Left;
                    break;
                case Keys.Right when Settings.CurrentDirection != Direction.Left:
                    Settings.CurrentDirection = Direction.Right;
                    break;
                case Keys.Up when Settings.CurrentDirection != Direction.Down:
                    Settings.CurrentDirection = Direction.Up;
                    break;
                case Keys.Down when Settings.CurrentDirection != Direction.Up:
                    Settings.CurrentDirection = Direction.Down;
                    break;
                case Keys.Enter when Settings.GameOver:
                    _snakeGame = new Game(pbCanvas.Width, pbCanvas.Height);
                    lblGameOver.Visible = false;
                    break;
            }
        }

        private void UpdateScreen(object sender, EventArgs e)
        {
            if (Settings.GameOver)
            {
                if (!lblGameOver.Visible)
                {
                    lblGameOver.Text = "GAME OVER\nPressione Enter para reiniciar";
                    lblGameOver.Visible = true;
                }
                return;
            }

            if (_snakeGame != null)
            {
                _snakeGame.Update();
                pbCanvas.Invalidate();
            }
        }

        private void pbCanvas_Paint(object sender, PaintEventArgs e)
        {
            Graphics canvas = e.Graphics;

            if (_snakeGame != null && !Settings.GameOver)
            {
                // Desenha a cobra
                for (int i = 0; i < _snakeGame.Snake.Count; i++)
                {
                    Brush snakeColour = (i == 0) ? Brushes.DarkGreen : Settings.SnakeColor;
                    canvas.FillEllipse(snakeColour,
                        new Rectangle(_snakeGame.Snake[i].X * Settings.Width,
                                      _snakeGame.Snake[i].Y * Settings.Height,
                                      Settings.Width, Settings.Height));
                }

                // Desenha a comida
                canvas.FillEllipse(Settings.FoodColor,
                    new Rectangle(_snakeGame.Food.X * Settings.Width,
                                  _snakeGame.Food.Y * Settings.Height,
                                  Settings.Width, Settings.Height));
            }

            if (_snakeGame != null)
            {
                lblScore.Text = $"Score: {Settings.Score}";
            }
        }

        private void pbCanvas_Click(object sender, EventArgs e)
        {

        }

        private void d(object sender, KeyEventArgs e)
        {

        }

        private void lblGameOver_Click(object sender, EventArgs e)
        {

        }

        private void lblScore_Click(object sender, EventArgs e)
        {

        }
    }
}