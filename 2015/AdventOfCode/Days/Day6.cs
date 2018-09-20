using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode.Days
{
    public class Day6 : IPuzzleDay
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

            List<Light> grid = new List<Light>();

            for (int i = 0; i < 1000; i++)
            {
                for (int j = 0; j < 1000; j++)
                {
                    grid.Add(new Light(i, j));
                }
            }

            foreach (var instruction in list)
            {
                List<string> coords = Regex.Matches(instruction, @"[0-9]{1,3}").Cast<Match>().Select(m => m.Value).ToList();

                int xStart = int.Parse(coords[0]);
                int yStart = int.Parse(coords[1]);
                int xEnd = int.Parse(coords[2]);
                int yEnd = int.Parse(coords[3]);

                var applicableLights = grid.Where(l => xStart <= l.X && l.X <= xEnd && yStart <= l.Y && l.Y <= yEnd);

                if (instruction.Contains("turn on"))
                {
                    foreach (var light in applicableLights)
                    {
                        light.Status = true;
                    }
                }
                else if (instruction.Contains("turn off"))
                {
                    foreach (var light in applicableLights)
                    {
                        light.Status = false;
                    }
                }
                else if (instruction.Contains("toggle"))
                {
                    foreach (var light in applicableLights)
                    {
                        light.Status = !light.Status;
                    }
                }
            }

            var answer = grid.Where(l => l.Status == true).Count();

            Console.WriteLine($"The number of lights still on at the end is: {answer}");
        }

        internal class Light
        {
            internal Light(int x, int y)
            {
                this.X = x;
                this.Y = y;
                this.Status = false;
            }

            internal int X { get; }
            internal int Y { get; }
            internal bool Status { get; set; }
        }
    }
}
