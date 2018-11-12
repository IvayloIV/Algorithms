using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Towers_of_Hanoi
{
    class Program
    {
        private static int steps = 1;
        private static Stack<int> source;
        private static Stack<int> destination = new Stack<int>();
        private static Stack<int> spare = new Stack<int>();

        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            source = new Stack<int>(Enumerable.Range(1, n).Reverse());
            PrintPath();
            MoveDisks(n, source, destination, spare);
        }

        private static void MoveDisks(int bottomDisks, Stack<int> source, Stack<int> destination, Stack<int> spare)
        {
            if (bottomDisks == 1)
            {
                destination.Push(source.Pop());
                Console.WriteLine($"Step #{steps++}: Moved disk");
                PrintPath();
            }
            else 
            {
                MoveDisks(bottomDisks - 1, source, spare, destination);
                destination.Push(source.Pop());
                Console.WriteLine($"Step #{steps++}: Moved disk");
                PrintPath();
                MoveDisks(bottomDisks - 1, spare, destination, source);
            }
        }

        private static void PrintPath()
        {
            Console.WriteLine($"Source: {string.Join(", ", source.Reverse())}");
            Console.WriteLine($"Destination: {string.Join(", ", destination.Reverse())}");
            Console.WriteLine($"Spare: {string.Join(", ", spare.Reverse())}");
            Console.WriteLine();
        }
    }
}