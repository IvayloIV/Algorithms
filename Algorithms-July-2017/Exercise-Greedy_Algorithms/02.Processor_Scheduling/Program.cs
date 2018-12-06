using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Processor_Scheduling
{
    class Program
    {
        static int totalValue;

        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine().Split(' ')[1]);
            var tasks = new List<Task>();

            for (int i = 0; i < n; i++)
            {
                var taskTokens = Console.ReadLine()
                    .Split(new[] { " - " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                var value = taskTokens[0];
                var deadline = taskTokens[1];

                tasks.Add(new Task(i + 1, value, deadline));
            }

            var completedTasks = CreateSchedule(tasks);
            PrintSchedule(completedTasks);
        }

        private static void PrintSchedule(List<Task> completedTasks)
        {
            Console.WriteLine("Optimal schedule: " + string.Join(" -> ", completedTasks
                .OrderBy(a => a.DeadLine)
                .ThenByDescending(a => a.Value)));

            Console.WriteLine($"Total value: {totalValue}");
        }

        private static List<Task> CreateSchedule(List<Task> tasks)
        {
            var completedTasks = new List<Task>();
            var steps = 0;

            while (true)
            {
                tasks = tasks
                    .Where(a => a.DeadLine > steps)
                    .OrderByDescending(a => a.Value / (a.DeadLine - steps))
                    .ToList();

                if (tasks.Count <= 0)
                {
                    break;
                }

                var currentTask = tasks.First();
                completedTasks.Add(currentTask);
                totalValue += currentTask.Value;
                steps++;
                tasks.Remove(currentTask);
            }

            return completedTasks;
        }
    }

    class Task 
    {
        public int Number { get; set; }

        public int Value { get; set; }

        public int DeadLine { get; set; }

        public Task(int number, int value, int deadline)
        {
            this.Number = number;
            this.Value = value;
            this.DeadLine = deadline;
        }

        public override string ToString()
        {
            return this.Number.ToString();
        }
    }
}