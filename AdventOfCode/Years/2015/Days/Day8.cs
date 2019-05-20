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
            foreach (var item in list)
            {
                var h = Encoding.Default.GetString(item);
                var a = Regex.Escape(Encoding.Default.GetString(item));
                var b = a.ToCharArray();
                var c = a.Length;

                Console.WriteLine(a);
            }
            //this isn't quite getting the right answer. When escaping \", it's returning \\". The AoC is expecting \\\". I'm not sure if I'm wrong or the site is :(

            return list.Sum(x => Regex.Escape(Encoding.Default.GetString(x)).Length + 4); //+4 because we're adding "\ to the start and \" to the end of each string
        }
    }
}
