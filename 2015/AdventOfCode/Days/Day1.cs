using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Days
{
    public class Day1 : IPuzzleDay
    {
        public void Run(string path)
        {
            var currentFloor = 0;
            var index = 0;
            var foundTheBasement = false;

            var reader = new StreamReader(path);
            var list = new List<char>();

            do
            {
                var ch = (char)reader.Read();
                list.Add(ch);
            }
            while (!reader.EndOfStream);
            reader.Close();

            foreach (var character in list)
            {
                if (currentFloor.Equals(-1) && !foundTheBasement)
                {
                    Console.WriteLine($"Santa entered the basement first at position: {index}");
                    foundTheBasement = true;
                }

                if (character.Equals('('))
                {
                    currentFloor++;
                }
                else if (character.Equals(')'))
                {
                    currentFloor--;
                }

                index++;
            }

            Console.WriteLine($"The final floor Santa arrives on is: {currentFloor}");
        }
	
    }
}
