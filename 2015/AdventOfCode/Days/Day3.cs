using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Days
{
    class Day3 : IPuzzleDay
    {
        public void Run(string path)
        {
            var reader = new StreamReader(path);
            var input = new List<char>();

            do
            {
                var ch = (char)reader.Read();
                input.Add(ch);
            }
            while (!reader.EndOfStream);
            reader.Close();

            List<int> grid = new List<int>();

            foreach (char character in input)
            {
                if (character.Equals('<'))
                {
                    ;//
                }
                else if (character.Equals('^'))
                {
                    ;//
                }
                else if (character.Equals('>'))
                {
                    ;//
                }
                else if (character.Equals('v'))
                {
                    ;//
                }
            }


        }
    }
}
