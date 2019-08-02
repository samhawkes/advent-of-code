using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Days;

namespace AdventOfCode.Years._2018.Days
{
    public class Day1 : IPuzzleDay
    {
        public void Run(string path)
        {
            var list = FileReader.ReadLineToStringList(path);

            var frequency = CalculateTotalFrequency(list);
            var duplicateFrequency = FindDuplicate(list);

            Console.WriteLine($"The total frequency at the end of the sequence starting from 0 is: {frequency}.");
            Console.WriteLine($"The first frequency that is reached twice is: {duplicateFrequency}.");
        }

        private int CalculateTotalFrequency(List<string> input)
        {
            var total = 0;

            foreach (var element in input)
                total += int.Parse(element);

            return total;
        }

        private int FindDuplicate(List<string> input)
        {
            var usedFrequencies = new List<int>();
            var currentFrequency = 0;
            var duplicateFound = false;
            var loopCount = 0;

            usedFrequencies.Add(currentFrequency);

            while (!duplicateFound)
            {
                loopCount++;
                var tempList = new List<string>();
                tempList.AddRange(input);
                while (!duplicateFound && tempList.Any())
                {
                    currentFrequency += int.Parse(tempList[0]);
                    tempList.RemoveAt(0);

                    if (usedFrequencies.Contains(currentFrequency))
                        duplicateFound = true;
                    else
                        usedFrequencies.Add(currentFrequency);
                }
            }

            Console.WriteLine($"Total loop count was: {loopCount}.");
            return currentFrequency;
        }
    }
}