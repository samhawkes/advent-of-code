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

            List<House> grid = new List<House>();

            grid.Add(new House())

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

        internal class House
        {
            internal House(int x, int y)
            {
                this.X = x;
                this.Y = y;
            }

            internal int X { get; set; }

            internal int Y { get; set; }

            internal int NumberOfPresents { get; set; }
        }

    }
}
