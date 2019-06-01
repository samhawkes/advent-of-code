using AdventOfCode.Days;
using System;
using System.IO;
using System.Reflection;

namespace AdventOfCode
{
    class Program
    {
        static void Main(string[] args)
        {
            var basePath = $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}";
            bool validYear = false;

            while (!validYear)
            {
                Console.WriteLine("\nWhich year would you like to solve? ");

                if (!uint.TryParse(Console.ReadLine(), out uint year))
                {
                    Console.WriteLine($"Please enter a valid positive integer.");
                    continue;
                }

                var yearsPath = Path.Combine(basePath, "Years", year.ToString());

                if (!Directory.Exists(yearsPath))
                {
                    Console.WriteLine($"There doesn't appear to be any solutions for {year}.");
                    continue;
                }

                validYear = true;

                bool solvePuzzles = true;

                while (solvePuzzles)
                {
                    var externalFilesPath = Path.Combine(yearsPath, "ExternalFiles");

                    Console.WriteLine($"\nCurrently looking at the {year} puzzles.");
                    Console.WriteLine("Which day would you like to solve? ");

                    if (!uint.TryParse(Console.ReadLine(), out uint day))
                    {
                        Console.WriteLine($"Please enter a valid positive integer.");
                        continue;
                    }

                    try
                    {
                        Type t = Assembly.GetExecutingAssembly().GetType($"AdventOfCode.Years._{year}.Days.Day{day}");
                        IPuzzleDay puzzleDay = (IPuzzleDay)Activator.CreateInstance(t);

                        var filePath = Path.Combine(externalFilesPath, $"Day{day}.txt");

                        puzzleDay.Run(filePath);
                    }
                    catch (ArgumentNullException)
                    {
                        Console.WriteLine($"Could not find a solution for day {day}.");
                    }
                    catch (FileNotFoundException)
                    {
                        Console.WriteLine($"Could not find an input file for day {day}.");
                    }

                    bool goodResponse = false;
                    do
                    {
                        Console.WriteLine("\nWould you like to solve another puzzle?");

                        var response = Console.ReadLine().ToLower();

                        if ((response.Equals("yes")) || (response.Equals("y")) || (response.Equals("ye")) || (response.Equals("yea")) || (response.Equals("yeah")) || (response.Equals("yis")) || (response.Equals("yup")))
                        {
                            goodResponse = true;
                            continue;
                        }

                        if ((response.Equals("no")) || (response.Equals("n")) || (response.Equals("na")) || (response.Equals("nah")) || (response.Equals("nope")) || (response.Equals("nop")))
                        {
                            Console.WriteLine("\nThanks for playing!");
                            goodResponse = true;
                            solvePuzzles = false;
                        }

                    } while (!goodResponse);
                }
            }
        }
    }
}
