using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Days
{
    public class Day2 : IPuzzleDay
    {
        public void Run(string path)
        {
            var reader = new StreamReader(path);
            var list = new List<string>();

            do
            {
                var line = reader.ReadLine();
                list.Add(line);
            }
            while (!reader.EndOfStream);
            reader.Close();

            int totalPaper = 0;
            int totalRibbon = 0;

            foreach (var box in list)
            {
                var boxSides = CalculateBoxSides(box);

                totalPaper += CalculateSquareFeetOfPaper(boxSides);
                totalRibbon += CalculateRibbonNeeded(box, boxSides);
            }

            Console.WriteLine($"The total paper required is: {totalPaper} square feet.");
            Console.WriteLine($"The total ribbon required is: {totalRibbon} feet.");
        }

        private int CalculateRibbonNeeded(string dimensions, Dictionary<string, int> boxSides)
        {
            var numbers = dimensions.Split('x');

            int length = int.Parse(numbers[0]);
            int width = int.Parse(numbers[1]);
            int height = int.Parse(numbers[2]);

            int boxVolume = length * width * height;
            int bow = boxVolume;

            var smallestSide = boxSides.Where(x => x.Value.Equals(boxSides.Min(kvp => kvp.Value)));

            int perimeter = 0;

            switch (smallestSide.First().Key)
            {
                case ("lw"):
                    perimeter = (2 * length) + (2 * width);
                    break;

                case ("wh"):
                    perimeter = (2 * width) + (2 * height);
                    break;

                case ("hl"):
                    perimeter = (2 * height) + (2 * length);
                    break;

                default:
                    break;
            }

            return perimeter + bow;
        }

        private int CalculateSquareFeetOfPaper(Dictionary<string, int> boxSides)
        {
            var boxArea = 0;
            var smallestSide = boxSides.Min(kvp => kvp.Value);

            foreach (var side in boxSides)
            {
                boxArea += side.Value * 2;
            }

            return boxArea + smallestSide;
        }

        private Dictionary<string, int> CalculateBoxSides(string dimensions)
        {
            var numbers = dimensions.Split('x');

            int length = int.Parse(numbers[0]);
            int width = int.Parse(numbers[1]);
            int height = int.Parse(numbers[2]);

            Dictionary<string, int> boxSides = new Dictionary<string, int>
            {
                { "lw", length * width },
                { "wh", width * height },
                { "hl", height * length }
            };

            return boxSides;
        }

    }
}
