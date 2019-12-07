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
            var input1 = new List<int>(input);
            var input2 = new List<int>(input);
            
            var part1Computation = Compute(input1, 12, 2);
            
            Console.WriteLine($"The value at position 0 after computation is: {part1Computation[0]}.");
            
            var part2Computation = new List<int>();
            var targetOutput = 19690720;

            for (int i = 0; i < 100; i++)
            {
                for (int j = 0; j < 100; j++)
                {
                    input2 = new List<int>(input);
                    part2Computation = Compute(input2, i, j);

                    if (part2Computation[0] == targetOutput)
                    {
                        var answer = 100 * i + j;
                        Console.WriteLine($"The value of (100 * noun) + verb for output {targetOutput} is: {answer}.");
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// Runs the IntCode program
        /// </summary>
        /// <param name="startList">The list of OpCodes</param>
        /// <param name="noun">The OpCode at position 1</param>
        /// <param name="verb">The OpCode at position 2</param>
        private List<int> Compute(List<int> startList, int noun, int verb)
        {
            startList[1] = noun;
            startList[2] = verb;
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