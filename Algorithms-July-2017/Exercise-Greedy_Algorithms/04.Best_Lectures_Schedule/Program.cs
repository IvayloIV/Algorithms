using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Best_Lectures_Schedule
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine().Split(' ')[1]);
            var lectures = new List<Lecture>();
            ReadLectures(lectures, n);
            var completedLectures = GetCompletedLectures(lectures);
            PrintResult(completedLectures);
        }

        private static void ReadLectures(List<Lecture> lectures, int n)
        {
            for (int i = 0; i < n; i++)
            {
                var tokens = Console.ReadLine().Split(' ').ToArray();
                var name = tokens[0].Substring(0, tokens[0].Length - 1);
                var startTime = int.Parse(tokens[1]);
                var finishTime = int.Parse(tokens[3]);

                lectures.Add(new Lecture(name, startTime, finishTime));
            }
        }

        private static void PrintResult(List<Lecture> completedLectures)
        {
            Console.WriteLine($"Lectures ({completedLectures.Count}):");

            foreach (var lecture in completedLectures)
            {
                Console.WriteLine(lecture);
            }
        }

        private static List<Lecture> GetCompletedLectures(List<Lecture> lectures)
        {
            var completedLectures = new List<Lecture>();
            var currentLecture = lectures.OrderBy(a => a.Finish).First();
            completedLectures.Add(currentLecture);

            foreach (var lecture in lectures.OrderBy(a => a.Start))
            {
                if (lecture.Start >= currentLecture.Finish)
                {
                    completedLectures.Add(lecture);
                    currentLecture = lecture;
                }
            }

            return completedLectures;
        }
    }

    class Lecture
    {
        public string Name { get; }
        public int Start { get; set; }
        public int Finish { get; set; }

        public Lecture(string name, int start, int finish)
        {
            this.Name = name;
            this.Start = start;
            this.Finish = finish;
        }

        public override string ToString()
        {
            return $"{this.Start}-{this.Finish} -> {this.Name}";
        }
    }
}