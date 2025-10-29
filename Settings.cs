using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SnakeFinal 
{
    public enum Direction
    {
        Up,
        Down,
        Left,
        Right
    };

    public static class Settings
    {
        public static int Width { get; set; } = 16;
        public static int Height { get; set; } = 16;
        public static int Speed { get; set; } = 3;
        public static int Score { get; set; } = 0;
        public static int Points { get; set; } = 10;
        public static bool GameOver { get; set; } = false;
        public static Direction CurrentDirection { get; set; } = Direction.Down;
        public static Brush SnakeColor { get; set; } = Brushes.Black;
        public static Brush FoodColor { get; set; } = Brushes.Red;
    }
}
