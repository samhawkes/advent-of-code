﻿using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AdventOfCode
{
    internal static class FileReader
    {
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

        internal static string ReadInputToString(string path)
        {
            var reader = new StreamReader(path);
            var input = reader.ReadToEnd();
            reader.Close();
            return input;
        }
    }
}