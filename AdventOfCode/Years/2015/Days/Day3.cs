using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Days;

namespace AdventOfCode.Years._2015.Days
{
    public class Day3 : IPuzzleDay
    {
        public void Run(string path)
        {
            var input = FileReader.ReadCharToCharList(path);

            var santasInput = new List<char>();
            var robotsInput = new List<char>();

            for (var i = 0; i < input.Count; i++)
            {
                if (i % 2 == 0)
                    santasInput.Add(input[i]);
                else
                    robotsInput.Add(input[i]);
            }

            var neighbourhood = new List<House>
            {
                new House(0, 0)
            };

            neighbourhood = MoveAndDeliver(santasInput, neighbourhood);
            neighbourhood = MoveAndDeliver(robotsInput, neighbourhood);

            Console.WriteLine($"The number of houses that received at least one present is {neighbourhood.Count()}.");
        }

        private List<House> MoveAndDeliver(List<char> splitInput, List<House> neighbourhood)
        {
            var globalX = 0;
            var globalY = 0;

            foreach (var character in splitInput)
            {
                switch (character)
                {
                    case '<':
                        globalX--;
                        break;
                    case '^':
                        globalY++;
                        break;
                    case '>':
                        globalX++;
                        break;
                    case 'v':
                        globalY--;
                        break;
                    default:
                        throw new ArgumentException($"An invalid character - \"{character}\" - is in the input file.");
                }

                var currentHouse = neighbourhood.FirstOrDefault(a => a.X.Equals(globalX) && a.Y.Equals(globalY));

                if (currentHouse == null)
                    neighbourhood.Add(new House(globalX, globalY));
                else
                    currentHouse.NumberOfPresents++;
            }

            return neighbourhood;
        }

        private class House
        {
            internal House(int x, int y)
            {
                X = x;
                Y = y;
                NumberOfPresents = 1;
            }

            internal int X { get; }

            internal int Y { get; }

            internal int NumberOfPresents { get; set; }
        }
    }
}