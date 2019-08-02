using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Days;

namespace AdventOfCode.Years._2015.Days
{
    public class Day2 : IPuzzleDay
    {
        public void Run(string path)
        {
            var list = FileReader.ReadLineToStringList(path);

            var totalPaper = 0;
            var totalRibbon = 0;

            foreach (var box in list)
            {
                var newBox = new Box(box);

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


        private class Box
        {
            internal Box(string dimensions)
            {
                var numbers = dimensions.Split('x');

                Length = int.Parse(numbers[0]);
                Width = int.Parse(numbers[1]);
                Height = int.Parse(numbers[2]);

                Volume = Length * Width * Height;
            }

            private int Length { get; }

            private int Width { get; }

            private int Height { get; }

            internal int Volume { get; }

            private int LxW => Length * Width;

            private int WxH => Width * Height;

            private int HxL => Height * Length;

            internal int Area => (2 * LxW) + (2 * WxH) + (2 * HxL);

            private List<int> SmallestSide
            {
                get
                {
                    var dimensions = new List<int>
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
}