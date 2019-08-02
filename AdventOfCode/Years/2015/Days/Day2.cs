using AdventOfCode.Days;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Years._2015.Days
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

            Length = int.Parse(numbers[0]);
            Width = int.Parse(numbers[1]);
            Height = int.Parse(numbers[2]);

            Volume = Length * Width * Height;
        }

        internal int Length { get; }

        internal int Width { get; }

        internal int Height { get; }

        internal int Volume { get; }

        internal int LxW => Length * Width;

        internal int WxH => Width * Height;

        internal int HxL => Height * Length;

        internal int Area => (2 * LxW) + (2 * WxH) + (2 * HxL);

        private List<int> SmallestSide
        {
            get
            {
                List<int> dimensions = new List<int>
                {
                    Length,
                    Width,
                    Height
                };

                dimensions.Remove(dimensions.Max());

                return dimensions;
            }
        }

        internal int AreaOfSmallestSide => SmallestSide[0] * SmallestSide[1];

        internal int PerimeterOfSmallestSide => (2 * SmallestSide[0]) + (2 * SmallestSide[1]);
    }

}
