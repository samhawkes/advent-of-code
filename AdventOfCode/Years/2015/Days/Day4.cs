using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using AdventOfCode.Days;

namespace AdventOfCode.Years._2015.Days
{
    public class Day4 : IPuzzleDay
    {
        public void Run(string path)
        {
            var input = FileReader.ReadInputToString(path);

            var md5Hash = ComputeHex(input);

            var answerString = md5Hash.Split(new[] {input}, StringSplitOptions.RemoveEmptyEntries).First();

            Console.WriteLine($"The smallest integer that gives an MD5 hash with 6 leading 0s for start-key {input} is: {answerString}.");
        }

        private string ComputeHex(string input)
        {
            var foundHash = false;
            var newString = string.Empty;

            for (var i = 0; !foundHash; i++)
            {
                newString = string.Concat(input, i.ToString());

                var hash = CalculateHash(newString);

                if (hash.StartsWith("000000"))
                    foundHash = true;
            }

            return newString;
        }

        private string CalculateHash(string input)
        {
            var md5 = MD5.Create();

            var inputBytes = Encoding.ASCII.GetBytes(input);

            var hash = md5.ComputeHash(inputBytes);

            var sb = new StringBuilder();

            foreach (var element in hash)
            {
                sb.Append(element.ToString("x2"));
            }

            return sb.ToString();
        }
    }
}