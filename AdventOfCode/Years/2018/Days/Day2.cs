using AdventOfCode.Days;
using System.Collections.Generic;
using System;
using System.Linq;

namespace AdventOfCode.Years._2018.Days
{
    public class Day2 : IPuzzleDay
    {
        public void Run(string path)
        {
            var list = FileReader.ReadLineToStringList(path);

            var lettersAppearTwice = CalculateOccurancesOfDoubleLetters(list);
            var lettersAppearThrice = CalculateOccurancesOfTripleLetters(list);

            Console.WriteLine($"The checksum for the list is: {lettersAppearTwice * lettersAppearThrice}.");            
        }

        private int CalculateOccurancesOfDoubleLetters(List<string> input)
        {
            var currentOccurancesOfDoubleLetters = 0;

            foreach (var boxID in input)
            {

            }

            return currentOccurancesOfDoubleLetters;
        }

        private uint CalculateOccurancesOfTripleLetters(List<string> input)
        {
            return 0;
        }
    }
}
