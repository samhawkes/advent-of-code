using System;
using System.Collections.Generic;
using AdventOfCode.Days;

namespace AdventOfCode.Years._2019.Days
{
    public class Day2 : IPuzzleDay
    {
        public void Run(string path)
        {
            var input = FileReader.ReadInputToCommaSeparatedIntList(path);

            var modifiedList = Compute(input);

            Console.WriteLine($"The value at position 0 after computation is: {modifiedList[0]}.");
        }

        private List<int> Compute(List<int> startList)
        {
            startList[1] = 12;
            startList[2] = 2;
            const int add = 1;
            const int multiply = 2;
            const int terminate = 99;

            for (var i = 0; i < startList.Count - 3; i += 4)
            {
                switch (startList[i])
                {
                    case terminate:
                        return startList;

                    case add:
                        startList[startList[i + 3]] = startList[startList[i + 1]] + startList[startList[i + 2]];
                        break;

                    case multiply:
                        startList[startList[i + 3]] = startList[startList[i + 1]] * startList[startList[i + 2]];
                        break;
                }
            }
            return startList;
        }
    }
}