using System;
using System.Collections.Generic;
using System.Linq;

namespace SnakeFinal
{
    public class Game
    {
        private readonly int _maxWidth;
        private readonly int _maxHeight;
        private readonly Random _rand = new Random();

        public List<Circle> Snake { get; private set; }
        public Circle Food { get; private set; }

        public Game(int canvasWidth, int canvasHeight)
        {
            _maxWidth = canvasWidth / Settings.Width;
            _maxHeight = canvasHeight / Settings.Height;

            StartGame();
        }

        public void StartGame()
        {
            Settings.GameOver = false;
            Settings.Score = 0;
            Settings.CurrentDirection = Direction.Down;

            Snake = new List<Circle>
            {
                new Circle { X = 10, Y = 5 }
            };

            GenerateFood();
        }

        private void GenerateFood()
        {
            int x, y;
            do
            {
                x = _rand.Next(0, _maxWidth);
                y = _rand.Next(0, _maxHeight);
            }
            while (Snake.Any(part => part.X == x && part.Y == y));

            Food = new Circle { X = x, Y = y };
        }

        // --- MÉTODO UPDATE (corrigido) ---
        public void Update()
        {
            if (Settings.GameOver) return;

            // 1. Pega a posição da cabeça atual
            var head = Snake.First();
            var newHead = new Circle { X = head.X, Y = head.Y };

            // 2. Move a nova cabeça na direção atual
            switch (Settings.CurrentDirection)
            {
                case Direction.Up: newHead.Y--; break;
                case Direction.Down: newHead.Y++; break;
                case Direction.Left: newHead.X--; break;
                case Direction.Right: newHead.X++; break;
            }

            // 3. Adiciona a nova cabeça na frente da cobra
            Snake.Insert(0, newHead);

            // 4. Verifica colisão com as bordas
            if (newHead.X < 0 || newHead.Y < 0 ||
                newHead.X >= _maxWidth || newHead.Y >= _maxHeight)
            {
                Settings.GameOver = true;
                return;
            }

            // 5. Verifica colisão com o próprio corpo
            for (int j = 1; j < Snake.Count; j++)
            {
                if (newHead.X == Snake[j].X && newHead.Y == Snake[j].Y)
                {
                    Settings.GameOver = true;
                    return;
                }
            }

            // 6. Verifica se comeu a comida
            if (newHead.X == Food.X && newHead.Y == Food.Y)
            {
                Eat();
            }
            else
            {
                // Se não comeu, remove o último segmento (mantém tamanho)
                Snake.RemoveAt(Snake.Count - 1);
            }
        }

        // --- MÉTODO EAT (corrigido) ---
        private void Eat()
        {
            Settings.Score += Settings.Points;

            // Posição do novo segmento que vamos tentar adicionar
            int newTailX = -1, newTailY = -1;

            if (Snake.Count == 1)
            {
                // Se só tem 1 segmento, usamos a direção oposta da direção atual da cabeça
                var last = Snake.Last();
                switch (Settings.CurrentDirection)
                {
                    case Direction.Up: newTailX = last.X; newTailY = last.Y + 1; break;
                    case Direction.Down: newTailX = last.X; newTailY = last.Y - 1; break;
                    case Direction.Left: newTailX = last.X + 1; newTailY = last.Y; break;
                    case Direction.Right: newTailX = last.X - 1; newTailY = last.Y; break;
                }
            }
            else
            {
                // Usa os dois últimos segmentos para inferir direção do rabo
                var tail = Snake[Snake.Count - 1];
                var beforeTail = Snake[Snake.Count - 2];

                int dx = tail.X - beforeTail.X;
                int dy = tail.Y - beforeTail.Y;

                newTailX = tail.X + dx;
                newTailY = tail.Y + dy;
            }

            // Função auxiliar: verifica se (x,y) está livre e dentro do mapa
            bool IsFree(int x, int y)
            {
                if (x < 0 || y < 0 || x >= _maxWidth || y >= _maxHeight) return false;
                return !Snake.Any(s => s.X == x && s.Y == y);
            }

            // Se a primeira tentativa for inválida, tenta posições adjacentes (ordem: continuar, esquerda, direita, trás)
            var candidatePositions = new List<(int x, int y)>();
            if (newTailX >= 0)
                candidatePositions.Add((newTailX, newTailY));

            // pega o tail atual (para propor alternativas)
            var realTail = Snake.Last();
            candidatePositions.Add((realTail.X + 1, realTail.Y));
            candidatePositions.Add((realTail.X - 1, realTail.Y));
            candidatePositions.Add((realTail.X, realTail.Y + 1));
            candidatePositions.Add((realTail.X, realTail.Y - 1));
            // por fim, como fallback, adiciona exatamente na posição do tail
            candidatePositions.Add((realTail.X, realTail.Y));

            (int fx, int fy) chosen = (-1, -1);
            foreach (var c in candidatePositions)
            {
                if (IsFree(c.x, c.y))
                {
                    chosen = c;
                    break;
                }
            }

            if (chosen.fx == -1)
            {
                // nenhum local válido encontrado (muito raro). adiciona no tail mesmo.
                chosen = (realTail.X, realTail.Y);
            }

            Snake.Add(new Circle { X = chosen.fx, Y = chosen.fy });

            // Logs de debug
            Console.WriteLine($"[EAT] SnakeCount após Eat: {Snake.Count} | NewTail: ({chosen.fx},{chosen.fy}) | Food was: ({Food.X},{Food.Y})");

            // Gera nova comida
            GenerateFood();

            Console.WriteLine($"[EAT] Food gerada em: ({Food.X},{Food.Y})");
        }


    }
}
