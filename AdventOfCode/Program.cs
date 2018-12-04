using AdventOfCode.Days;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                var basePath = $@"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\ExternalFiles\";

                Console.WriteLine("\nWhich day would you like to solve? ");

                if (!uint.TryParse(Console.ReadLine(), out uint day))
                {
                    Console.WriteLine($"Please enter a valid positive integer.");
                    continue;
                }

                try
                {
                    Type t = Assembly.GetExecutingAssembly().GetType($"AdventOfCode.Days.Day{day}");
                    IPuzzleDay puzzleDay = (IPuzzleDay)Activator.CreateInstance(t);

                    puzzleDay.Run(basePath + $"Day{day}.txt");
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine($"Could not find a solution for day {day}.");
                }
                catch (FileNotFoundException)
                {
                    Console.WriteLine($"Could not find an input file for day {day}.");
                }
            }
        }
    }
}
