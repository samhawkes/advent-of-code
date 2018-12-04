using System;

namespace AdventOfCode.Days
{
    public class Day1 : IPuzzleDay
    {
        public void Run(string path)
        {
            var list = FileReader.ReadCharToCharList(path);

            var currentFloor = 0;
            var index = 0;
            var foundTheBasement = false;

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
