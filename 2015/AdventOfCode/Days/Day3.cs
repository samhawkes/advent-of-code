using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Days
{
    class Day3 : IPuzzleDay
    {
        public void Run(string path)
        {
            var input = FileReader.ReadCharToCharList(path);

            var santasInput = new List<char>();
            var robotsInput = new List<char>();

            for (int i = 0; i < input.Count; i++)
            {
                if (i % 2 == 0)
                    santasInput.Add(input[i]);
                else
                    robotsInput.Add(input[i]);
            }

            List<House> neighbourhood = new List<House>
            {
                new House(0, 0)
            };

            neighbourhood = this.MoveAndDeliver(santasInput, neighbourhood);
            neighbourhood = this.MoveAndDeliver(robotsInput, neighbourhood);

            Console.WriteLine($"The number of houses that received at least one present is {neighbourhood.Count()}.");
        }

        private List<House> MoveAndDeliver(List<char> splitInput, List<House> neighbourhood)
        {
            var globalX = 0;
            var globalY = 0;

            foreach (char character in splitInput)
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

            return neighbourhood;
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
