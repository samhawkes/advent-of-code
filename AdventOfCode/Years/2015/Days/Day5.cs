using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Days;

namespace AdventOfCode.Years._2015.Days
{
    public class Day5 : IPuzzleDay
    {
        public void Run(string path)
        {
            var list = FileReader.ReadLineToStringList(path);

            var answer1 = CalculateTheAnswer(list, IsItNicePart1);
            var answer2 = CalculateTheAnswer(list, IsItNicePart2);

            Console.WriteLine($"The number of nice strings using part 1's method is: {answer1}.");
            Console.WriteLine($"The number of nice strings using part 2's method is: {answer2}.");
        }

        private int CalculateTheAnswer(IEnumerable<string> list, Func<string, bool> isItNice)
        {
            List<string> naughty = new List<string>();
            List<string> nice = new List<string>();
            
            foreach (var word in list)
            {
                if (isItNice(word))
                {
                    nice.Add(word);
                }
                else
                {
                    naughty.Add(word);
                }
            }

            return nice.Count;
        }

        private bool IsItNicePart2(string word)
        {
            List<char> wordArray = new List<char>(word);
            bool spacedDouble = false;
            bool doubleChar = false;

            for (int i = 0, j = 2; j < wordArray.Count; i++, j++)
            {
                if (wordArray[i].Equals(wordArray[j]))
                {
                    spacedDouble = true;
                    break;
                }
            }

            for (int i = 0, j = 1; j < wordArray.Count; i++, j++)
            {
                List<char> wordArrayCopy = new List<char>(word);
                string subString = wordArrayCopy.ElementAt(i) + wordArrayCopy.ElementAt(j).ToString();
                string splitWord = word.Remove(0, j+1);

                if (splitWord.Contains(subString))
                    doubleChar = true;
            }

            return spacedDouble && doubleChar;
        }

        private bool IsItNicePart1(string word)
        {
            List<string> badStrings = new List<string>
            {
                "ab",
                "cd",
                "pq",
                "xy"
            };

            char[] vowels = {
                'a',
                'e',
                'i',
                'o',
                'u'
            };

            if (badStrings.Any(word.Contains))
            {
                return false;
            }

            if (word.ToCharArray().Where(vowels.Contains).Count() < 3)
            {
                return false;
            }

            var wordArray = word.ToCharArray();
            for (int i = 0, j = 1; j < wordArray.Length; i++, j++)
            {
                if (wordArray[i].Equals(wordArray[j]))
                {
                    return true;
                }
            }
            return false;
        }


    }
}
