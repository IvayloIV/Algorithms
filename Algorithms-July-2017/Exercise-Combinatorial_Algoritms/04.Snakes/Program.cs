using System;
using System.Collections.Generic;

namespace _04.Snakes
{
    class Program
    {
        static HashSet<string> visited = new HashSet<string>();
        static HashSet<string> snakes = new HashSet<string>();
        static char[] currentSnake;
        static int count;

        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            currentSnake = new char[n];
            currentSnake[0] = 'S';
            visited.Add(0 + " " + 0);

            GenerateSnake(1, 0, 1, 'R');
            Console.WriteLine($"Snakes count = {count}");
        }

        private static void GenerateSnake(int index, int row, int col, char direction)
        {
            if (index > currentSnake.Length - 1)
            {
                var currentSnakeStr = new string(currentSnake);
                if (!snakes.Contains(currentSnakeStr))
                {
                    AddSnakes();
                }
                return;
            }

            var position = row + " " + col;
            if (!visited.Contains(position))
            {
                visited.Add(position);
                currentSnake[index] = direction;
                GenerateSnake(index + 1, row, col + 1, 'R');
                GenerateSnake(index + 1, row + 1, col, 'D');
                GenerateSnake(index + 1, row, col - 1, 'L');
                GenerateSnake(index + 1, row - 1, col, 'U');
                visited.Remove(position);
            }
        }

        private static void AddSnakes()
        {
            var flipped = new string(Flip());
            var reverse = new string(Reverse());

            if (!snakes.Contains(flipped) && !snakes.Contains(reverse))
            {
                snakes.Add(flipped);
                snakes.Add(reverse);
                count++;
                Console.WriteLine(string.Join("", currentSnake));
            }
        }

        private static char[] Reverse()
        {
            var reversedSnake = new char[currentSnake.Length];
            reversedSnake[0] = 'S';
            for (int i = currentSnake.Length - 1; i >= 1; i--)
            {
                reversedSnake[currentSnake.Length - i] = currentSnake[i];
            }

            Rotate(reversedSnake);
            return reversedSnake;
        }

        private static char[] Flip()
        {
            var flippedSnake = new char[currentSnake.Length];
            flippedSnake[0] = 'S';
            for (int i = 1; i < currentSnake.Length; i++)
            {
                if (currentSnake[i] == 'U')
                {
                    flippedSnake[i] = 'D';
                }
                else if (currentSnake[i] == 'D')
                {
                    flippedSnake[i] = 'U';
                }
                else
                {
                    flippedSnake[i] = currentSnake[i];
                }
            }

            Rotate(flippedSnake);
            return flippedSnake;
        }

        private static void Rotate(char[] snake)
        {
            while (snake[1] != 'R')
            {
                for (int i = 1; i < snake.Length; i++)
                {
                    switch (snake[i])
                    {
                        case 'U': snake[i] = 'R'; break;
                        case 'R': snake[i] = 'D'; break;
                        case 'D': snake[i] = 'L'; break;
                        case 'L': snake[i] = 'U'; break;
                    }
                }
            }
        }
    }
}