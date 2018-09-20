using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Days
{
    public class Day5 : IPuzzleDay
    {
        public void Run(string path)
        {
            var reader = new StreamReader(path);
            var list = new List<string>();

            do
            {
                var line = reader.ReadLine();
                list.Add(line);
            }
            while (!reader.EndOfStream);
            reader.Close();

            List<string> naughty = new List<string>();
            List<string> nice = new List<string>();

            foreach (var word in list)
            {
                if (this.IsItNice(word))
                {
                    nice.Add(word);
                }
                else
                {
                    naughty.Add(word);
                }
            }

            var answer = nice.Count;

            Console.WriteLine($"The number of nice strings is: {answer}.");
        }

        private bool IsItNice(string word)
        {
            List<string> badStrings = new List<string>
            {
                "ab",
                "cd",
                "pq",
                "xy"
            };

            char[] vowels = new char[5]
            {
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
            else if (word.ToCharArray().Where(vowels.Contains).Count() < 3)
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
                else
                {
                    continue;
                }
            }
            return false;
        }


    }
}
