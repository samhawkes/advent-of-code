using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Days;

namespace AdventOfCode.Years._2017.Days
{
    public class Day2 : IPuzzleDay
    {
        public void Run(string path)
        {
            var input = FileReader.ReadInputToString(path);

            var allRows = input.Replace("\n", "").Split('\r');
            var sortedArray = new List<int[]>();

            foreach (var row in allRows)
            {
                var rowArray = row.Split('\t');
                sortedArray.Add(rowArray.Select(int.Parse).ToArray());
            }

            var largestMinusSmallestChecksum = CalculateLargestMinusSmallestChecksum(sortedArray);
            var evenlyDivisibleChecksum = CalculateEvenlyDivisibleChecksum(sortedArray);

            Console.WriteLine($"The sum of the largest of each row minus the smallest of each row is: {largestMinusSmallestChecksum}.");
            Console.WriteLine($"The sum of the results of the evenly divisible numbers in each row is: {evenlyDivisibleChecksum}.");
        }


        private int CalculateLargestMinusSmallestChecksum(List<int[]> sortedArray)
        {
            var sum = 0;

            foreach (var row in sortedArray)
            {
                var largestInRow = row[0];
                var smallestInRow = row[0];

                for (var i = 0; i < row.Length; i++)
                {
                    if (row[i] > largestInRow)
                        largestInRow = row[i];

                    if (row[i] < smallestInRow)
                        smallestInRow = row[i];
                }

                var difference = largestInRow - smallestInRow;
                sum += difference;
            }

            return sum;
        }

        private int CalculateEvenlyDivisibleChecksum(List<int[]> sortedArray)
        {
            var sum = 0;

            foreach (var row in sortedArray)
            {
                var result = 0;

                foreach (var element in row)
                {
                    for (var i = 0; i < row.Length; i++)
                    {
                        if (element % row[i] == 0 && element / row[i] != 1)
                            result = element / row[i];
                    }
                }
                
                sum += result;
            }

            return sum;
        }
    }
}