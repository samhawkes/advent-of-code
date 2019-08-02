using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using AdventOfCode.Days;

namespace AdventOfCode.Years._2015.Days
{
    public class Day8 : IPuzzleDay
    {
        public void Run(string path)
        {
            var list = FileReader.ReadLineToByteArrayList(path);

            var charactersOfCode = CalculateCharactersOfCode(list);
            var charactersInMemory = CalculateCharactersInMemory(list);
            var charactersInEncodedString = CalculateCharactersInEncodedString(list);

            Console.WriteLine($"The number of characters of code in the list of inputs is: {charactersOfCode}.");
            Console.WriteLine($"The number of characters in memory for the strings in the list is: {charactersInMemory}.");
            Console.WriteLine($"The number of characters in the list of encoded strings is: {charactersInEncodedString}.");

            Console.WriteLine($"\nThe number of characters of code, minus the number of characters in memory is: {charactersOfCode - charactersInMemory}.");
            Console.WriteLine($"\nThe number of encoded characters, minus the number of characters of code is: {charactersInEncodedString - charactersOfCode}.");
        }

        private int CalculateCharactersOfCode(List<byte[]> list)
        {
            return list.Sum(x => x.Length);
        }

        private int CalculateCharactersInMemory(List<byte[]> list)
        {
            return list.Sum(x => Regex.Unescape(Encoding.Default.GetString(x)).Length - 2); //-2 because we're ignoring the start and end quotes
        }

        private int CalculateCharactersInEncodedString(List<byte[]> list)
        {
            var quoteCount = 0;
            const string pattern = "\\\"";

            list.ForEach(y => quoteCount += Regex.Matches(Encoding.Default.GetString(y), pattern).Count - 2);
            //For some reason the way .NET is escaping the strings, it's escaping \" as \\" instead of \\\", so this ForEach is finding every occurrence of \" in the strings to add 1 for each to the total

            return list.Sum(x => Regex.Escape(Encoding.Default.GetString(x)).Length + 4) + quoteCount; //+4 because we're adding "\ to the start and \" to the end of each string
        }
    }
}