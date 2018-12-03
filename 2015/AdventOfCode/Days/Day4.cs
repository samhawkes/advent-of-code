using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace AdventOfCode.Days
{
    public class Day4 : IPuzzleDay
    {
        public void Run(string path)
        {
            var input = FileReader.ReadInputToString(path);

            var md5Hash = this.ComputeHex(input);

            var answerString = md5Hash.Split(new[] { input }, StringSplitOptions.RemoveEmptyEntries).First();

            Console.WriteLine($"The smallest integer that gives an MD5 hash with 6 leading 0s for start-key {input} is: {answerString}.");
        }

        private string ComputeHex(string input)
        {
            bool foundHash = false;
            string newString = string.Empty;

            for (int i = 0; !foundHash; i++)
            {
                newString = string.Concat(input, i.ToString());

                var hash = this.CalculateHash(newString);

                if (hash.StartsWith("000000"))
                    foundHash = true;
            }
            return newString;
        }

        private string CalculateHash(string input)
        {
            MD5 md5 = MD5.Create();

            byte[] inputBytes = Encoding.ASCII.GetBytes(input);

            byte[] hash = md5.ComputeHash(inputBytes);

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("x2"));
            }

            return sb.ToString();
        }
    }
}
