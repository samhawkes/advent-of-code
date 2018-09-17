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

            foreach (var box in list)
            {
                totalPaper += CalculateSquareFeetOfPaper(box);
            }

        }
	
        private int CalculateSquareFeetOfPaper(string dimensions)
        {
            var numbers = dimensions.Split('x');

            int length = int.Parse(numbers[0]);
            int width = int.Parse(numbers[1]);
            int height = int.Parse(numbers[2]);

            return 1;
        }



    }
}
