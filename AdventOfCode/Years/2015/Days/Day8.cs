using AdventOfCode.Days;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode.Years._2015.Days
{
    public class Day8 : IPuzzleDay
    {
        public void Run(string path)
        {
            var list = FileReader.ReadLineToByteArrayList(path);

            var charactersOfCode = CalculateCharactersOfCode(list);
            var charactersInMemory = CalculateCharactersInMemory(list);

            Console.WriteLine($"The number of characters of code in the list of inputs is: {charactersOfCode}.");
            Console.WriteLine($"The number of characters in memory for the strings in the list is: {charactersInMemory}.");

            Console.WriteLine($"\nThe number of characters of code, minus the number of characters in memory is: {charactersOfCode - charactersInMemory}.");
        }

        private int CalculateCharactersOfCode(List<byte[]> list)
        {
            return list.Sum(x => x.Length);
        }

        private int CalculateCharactersInMemory(List<byte[]> list)
        {
            return list.Sum(x => Regex.Unescape(Encoding.Default.GetString(x)).Length - 2); //-2 because we're ignoring the start and end quotes
        }
    }
}
