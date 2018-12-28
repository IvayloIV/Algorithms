using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Parking_Zones
{
    class Program
    {
        static void Main(string[] args)
        {
            int zonesCount = int.Parse(Console.ReadLine());
            List<Zone> zones = new List<Zone>();
            ReadZones(zonesCount, zones);

            string[] freeParkingSpots = Console.ReadLine()
                .Split(new[] { "; " }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            int[] targetPoint = Console.ReadLine()
                .Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int targetX = targetPoint[0];
            int targetY = targetPoint[1];
            int time = int.Parse(Console.ReadLine());

            Cell targetCell = GetBestParkingCell(zones, freeParkingSpots, targetX, targetY, time);
            decimal cellSum = targetCell.CalculateSum(targetCell.CalculateTime(targetX, targetY, time));
            Console.WriteLine($"Zone Type: {targetCell.ZoneName}; X: {targetCell.MinX}; Y: {targetCell.MinY}; Price: {cellSum:f2}");
        }

        static Cell GetBestParkingCell(List<Zone> zones, string[] freeParkingSpots, int targetX, int targetY, int time)
        {
            Cell targetCell = null;
            foreach (var freeSpot in freeParkingSpots)
            {
                int[] tokens = freeSpot.Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int x = tokens[0];
                int y = tokens[1];

                foreach (var zone in zones)
                {
                    if (zone.IsInside(x, y))
                    {
                        Cell newCell = new Cell(x, x + 1, y, y + 1, zone.Price, zone.ZoneName);
                        if (targetCell == null || targetCell.CompareWith(newCell, targetX, targetY, time))
                        {
                            targetCell = newCell;
                        }
                        break;
                    }
                }
            }

            return targetCell;
        }

        static void ReadZones(int zonesCount, List<Zone> zones)
        {
            for (int i = 0; i < zonesCount; i++)
            {
                string[] tokens = Console.ReadLine()
                    .Split(new[] { ": ", ", " }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string name = tokens[0];
                int minX = int.Parse(tokens[1]);
                int maxX = minX + int.Parse(tokens[3]);
                int minY = int.Parse(tokens[2]);
                int maxY = minY + int.Parse(tokens[4]);
                decimal price = decimal.Parse(tokens[5]);

                zones.Add(new Zone(minX, maxX, minY, maxY, name, price));
            }
        }
    }

    class Cell
    {
        public int MinX { get; set; }

        public int MaxX { get; set; }

        public int MinY { get; set; }

        public int MaxY { get; set; }

        public decimal Price { get; set; }

        public string ZoneName { get; set; }

        public Cell(int minX, int maxX, int minY, int maxY, decimal price, string zoneName)
        {
            this.MinX = minX;
            this.MaxX = maxX;
            this.MinY = minY;
            this.MaxY = maxY;
            this.Price = price;
            this.ZoneName = zoneName;
        }

        public bool CompareWith(Cell newCell, int targetX, int targetY, int time)
        {
            decimal currentCellTime = this.CalculateTime(targetX, targetY, time);
            decimal newCellTime = newCell.CalculateTime(targetX, targetY, time);

            decimal currentCellSum = this.CalculateSum(currentCellTime);
            decimal newCellSum = newCell.CalculateSum(newCellTime);

            if (currentCellSum != newCellSum)
            {
                return newCellSum < currentCellSum;
            }
            return newCellTime < currentCellTime;
        }

        public decimal CalculateSum(decimal time)
        {
            return Math.Ceiling(time) * this.Price;
        }

        public decimal CalculateTime(int targetX, int targetY, int time)
        {
            decimal sum = Math.Abs(this.MinX - targetX) + Math.Abs(this.MinY - targetY) - 1;
            sum = sum * 2 * time / 60m;
            return sum;
        }
    }

    class Zone : Cell
    {
        public Zone(int minX, int maxX, int minY, int maxY, string name, decimal price) 
            : base(minX, maxX, minY, maxY, price, name)
        { }

        public bool IsInside(int x, int y)
        {
            bool horizontal = this.MinX <= x + 1 && this.MaxX >= x;
            bool vertical = this.MinY <= y + 1 && this.MaxY >= y;
            return horizontal && vertical;
        }
    }
}