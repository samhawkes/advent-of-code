using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode
{
    internal static class FileReader
    {
        /// <summary>
        /// Reads an input and splits it by line, returning a list of strings
        /// </summary>
        /// <param name="path">The file path of the input</param>
        /// <returns></returns>
        internal static List<string> ReadLineToStringList(string path)
        {
            var reader = new StreamReader(path);
            var list = new List<string>();

            do
            {
                var line = reader.ReadLine();
                list.Add(line);
            } while (!reader.EndOfStream);

            reader.Close();

            return list;
        }

        /// <summary>
        /// Reads an input and splits it by line, returning a list of Byte Arrays
        /// </summary>
        /// <param name="path">The file path of the input</param>
        /// <returns></returns>
        internal static List<byte[]> ReadLineToByteArrayList(string path)
        {
            var reader = new StreamReader(path);
            var list = new List<byte[]>();

            do
            {
                var line = reader.ReadLine();
                list.Add(Encoding.Default.GetBytes(line));
            } while (!reader.EndOfStream);

            return list;
        }

        /// <summary>
        /// Reads an input and returns it as a list of the characters
        /// </summary>
        /// <param name="path">The file path of the input</param>
        internal static List<char> ReadCharToCharList(string path)
        {
            var reader = new StreamReader(path);
            var list = new List<char>();

            do
            {
                var ch = (char) reader.Read();
                list.Add(ch);
            } while (!reader.EndOfStream);

            reader.Close();

            return list;
        }

        /// <summary>
        /// Reads an input and returns it as one string
        /// </summary>
        /// <param name="path">The file path of the input</param>
        internal static string ReadInputToString(string path)
        {
            var reader = new StreamReader(path);
            var input = reader.ReadToEnd();
            reader.Close();
            return input;
        }

        /// <summary>
        /// Reads an input and splits it on commas to return a list of strings
        /// </summary>
        /// <param name="path">The file path of the input</param>
        internal static List<string> ReadInputToCommaSeparatedStringList(string path)
        {
            var reader = new StreamReader(path);
            var input = reader.ReadToEnd();

            return input.Split(',').ToList();
        }
        
        /// <summary>
        /// Reads an input and splits it on commas to return a list of ints
        /// </summary>
        /// <param name="path">The file path of the input</param>
        internal static List<int> ReadInputToCommaSeparatedIntList(string path)
        {
            var reader = new StreamReader(path);
            var input = reader.ReadToEnd();

            return input.Split(',').Select(int.Parse).ToList();
        }
    }
}