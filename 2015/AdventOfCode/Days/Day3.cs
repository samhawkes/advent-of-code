using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Days
{
    class Day3 : IPuzzleDay
    {
        public void Run(string path)
        {
            var reader = new StreamReader(path);
            var input = new List<char>();

            do
            {
                var ch = (char)reader.Read();
                input.Add(ch);
            }
            while (!reader.EndOfStream);
            reader.Close();

            var globalX = 0;
            var globalY = 0;

            List<House> neighbourhood = new List<House>
            {
                new House(globalX, globalY)
            };

            foreach (char character in input)
            {
                if (character.Equals('<'))
                {
                    globalX--;
                }
                else if (character.Equals('^'))
                {
                    globalY++;
                }
                else if (character.Equals('>'))
                {
                    globalX++;
                }
                else if (character.Equals('v'))
                {
                    globalY--;
                }

                var currentHouse = neighbourhood.FirstOrDefault(a => a.X.Equals(globalX) && a.Y.Equals(globalY));

                if (currentHouse == null)
                {
                    neighbourhood.Add(new House(globalX, globalY));
                }
                else
                {
                    currentHouse.NumberOfPresents++;
                }
            }

            Console.WriteLine($"The number of houses that received at least one present is {neighbourhood.Count()}.");
        }

        internal class House
        {
            internal House(int x, int y)
            {
                this.X = x;
                this.Y = y;
                this.NumberOfPresents = 1;
            }

            internal int X { get; }

            internal int Y { get; }

            internal int NumberOfPresents { get; set; }
        }
    
    }
}
