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

            var lettersAppearTwice = CalculateOccurrencesOfMultipleLetters(list, 2);
            var lettersAppearThrice = CalculateOccurrencesOfMultipleLetters(list, 3);

            var commonLetters = CalculateCommonLetters(list);

            Console.WriteLine($"The checksum for the list is: {lettersAppearTwice * lettersAppearThrice}.");
            Console.WriteLine($"The common letters between the two correct box IDs are: {commonLetters}.");
        }

        private int CalculateOccurrencesOfMultipleLetters(List<string> input, int numberOfOccurrences)
        {
            var currentOccurrencesOfMultipleLetters = 0;

            foreach (var boxID in input)
            {
                var array = boxID.ToCharArray();

                foreach (var distinct in array.Distinct())
                {
                    if (array.Count(i => i == distinct) == numberOfOccurrences)
                    {
                        currentOccurrencesOfMultipleLetters++;
                        break;
                    }
                }
            }

            return currentOccurrencesOfMultipleLetters;
        }

        private string CalculateCommonLetters(List<string> input)
        {
            var commonLetters = string.Empty;
            return commonLetters;
        }
    }
}
