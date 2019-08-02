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

            foreach (var boxId in input)
            {
                var array = boxId.ToCharArray();

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
            foreach (var boxId in input)
            {
                var currentIdArray = boxId.ToCharArray();

                for (int i = 1; i < input.Count; i++)
                {
                    var differentLetters = new List<int>();
                    var checkingIdArray = input[i].ToCharArray();

                    for (int j = 0; j < currentIdArray.Length; j++)
                    {
                        if (currentIdArray[j] != checkingIdArray[j])
                            differentLetters.Add(j);

                        if (differentLetters.Count > 1)
                            break;
                    }

                    if (differentLetters.Count == 1)
                    {
                        return new string(currentIdArray).Remove(differentLetters[0], 1);
                    }
                        

                }
            }

            return "There were no IDs that differed by exactly one character.";
        }
    }
}
