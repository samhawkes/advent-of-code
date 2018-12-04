using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Days
{
    public class Day2 : IPuzzleDay
    {
        public void Run(string path)
        {
            var list = FileReader.ReadLineToStringList(path);

            int totalPaper = 0;
            int totalRibbon = 0;

            foreach (var box in list)
            {
                Box newBox = new Box(box);

                totalPaper += CalculateSquareFeetOfPaper(newBox);
                totalRibbon += CalculateRibbonNeeded(newBox);
            }

            Console.WriteLine($"The total paper required is: {totalPaper} square feet.");
            Console.WriteLine($"The total ribbon required is: {totalRibbon} feet.");
        }

        private int CalculateRibbonNeeded(Box box)
        {
            return box.PerimeterOfSmallestSide + box.Volume;
        }

        private int CalculateSquareFeetOfPaper(Box box)
        {
            return box.Area + box.AreaOfSmallestSide;
        }
    }

    internal class Box
    {
        internal Box(string dimensions)
        {
            var numbers = dimensions.Split('x');

            this.Length = int.Parse(numbers[0]);
            this.Width = int.Parse(numbers[1]);
            this.Height = int.Parse(numbers[2]);

            this.Volume = Length * Width * Height;
        }

        internal int Length { get; }

        internal int Width { get; }

        internal int Height { get; }

        internal int Volume { get; }

        internal int LxW => this.Length * this.Width;

        internal int WxH => this.Width * this.Height;

        internal int HxL => this.Height * this.Length;

        internal int Area => (2 * this.LxW) + (2 * this.WxH) + (2 * this.HxL);

        private List<int> SmallestSide
        {
            get
            {
                List<int> dimensions = new List<int>
                {
                    this.Length,
                    this.Width,
                    this.Height
                };

                dimensions.Remove(dimensions.Max());

                return dimensions;
            }
        }

        internal int AreaOfSmallestSide => this.SmallestSide[0] * this.SmallestSide[1];

        internal int PerimeterOfSmallestSide => (2 * this.SmallestSide[0]) + (2 * this.SmallestSide[1]);
    }

}
