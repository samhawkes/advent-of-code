using AdventOfCode.Days;
using System;
using System.Linq;

namespace AdventOfCode.Years._2017.Days
{
    public class Day1 : IPuzzleDay
    {
        public void Run(string path)
        {
            var number = FileReader.ReadInputToString(path);

            var sumOfAdjacentDigits = CalculateSumOfAdjacentDigits(number);
            var sumOfHalfWayRoundDigits = CalculateSumOfHalfWayRoundDigits(number);

            Console.WriteLine($"The sum of the digits that match their adjacent is: {sumOfAdjacentDigits}.");
            Console.WriteLine($"The sum of the digits that match those half way round the list is: {sumOfHalfWayRoundDigits}.");
        }

        private int CalculateSumOfAdjacentDigits(string input)
        {
            var list = input.Select(x => x - '0').ToArray();
            var length = list.Count();

            var sum = 0;

            for (int j = 0; j < length; j++)
            {
                if (j < length - 1)
                {
                    if (list[j] == list[j + 1])
                        sum += list[j];
                }
                else
                {
                    if (list[j] == list[0])
                        sum += list[j];
                }
            }

            return sum;
        }

        private int CalculateSumOfHalfWayRoundDigits(string input)
        {
            var list = input.Select(x => x - '0').ToArray();
            var length = list.Count();

            var sum = 0;

            for (int j = 0; j < length; j++)
            {
                if (j < length / 2)
                {
                    if (list[j] == list[j + length / 2])
                        sum += list[j];
                }
                else if (j >= length / 2)
                {
                    if (list[j] == list[j - length / 2])
                        sum += list[j];
                }
            }

            return sum;
        }

    }
}