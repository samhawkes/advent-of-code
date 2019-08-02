using AdventOfCode.Days;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode.Years._2015.Days
{
    public class Day6 : IPuzzleDay
    {
        public void Run(string path)
        {
            var list = FileReader.ReadLineToStringList(path);

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
                grid = CalculateLightStatus(grid, instruction);
            }

            var lightsOn = grid.Count(l => l.Status);
            var brightness = CalculateTotalBrightness(grid);

            Console.WriteLine($"The number of lights still on at the end is: {lightsOn}."); //Part 1
            Console.WriteLine($"The total brightness at the end is: {brightness}."); //Part 2
        }

        private List<Light> CalculateLightStatus(List<Light> grid, string instruction)
        {
            List<string> coords = Regex.Matches(instruction, @"[0-9]{1,3}").Select(m => m.Value).ToList();

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
                    light.Brightness++;
                }
            }
            else if (instruction.Contains("turn off"))
            {
                foreach (var light in applicableLights)
                {
                    light.Status = false;
                    light.DecrementBrightness();
                }
            }
            else if (instruction.Contains("toggle"))
            {
                foreach (var light in applicableLights)
                {
                    light.Status = !light.Status;
                    light.Brightness += 2;
                }
            }

            return grid;
        }

        private int CalculateTotalBrightness(List<Light> grid)
        {
            var totalBrightness = 0;

            foreach (var light in grid)
            {
                totalBrightness += light.Brightness;
            }

            return totalBrightness;
        }
    }

    internal class Light
    {
        internal Light(int x, int y)
        {
            X = x;
            Y = y;
            Status = false;
        }

        internal int X { get; }
        internal int Y { get; }
        internal bool Status { get; set; }
        internal int Brightness { get; set; }

        internal void DecrementBrightness()
        {
            if (Brightness > 0)
                Brightness -= 1;
            else
                Brightness = 0;
        }
    }
}
