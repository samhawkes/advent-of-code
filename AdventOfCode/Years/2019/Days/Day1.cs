using System;
using AdventOfCode.Days;

namespace AdventOfCode.Years._2019.Days
{
    public class Day1 : IPuzzleDay
    {
        public void Run(string path)
        {
            var totalFuel = 0;
            var modifiedTotalFuel = 0;
            
            var list = FileReader.ReadLineToStringList(path);

            foreach (var module in list)
            {
                totalFuel += CalculateFuelForModule(int.Parse(module));
            }

            foreach (var module in list)
            {
                var moduleFuelNeeded = CalculateFuelForModule(int.Parse(module));
                modifiedTotalFuel += moduleFuelNeeded;
                
                while (CalculateFuelForModule(moduleFuelNeeded) > 0)
                {
                    var fuelNeededForFuel = CalculateFuelForModule(moduleFuelNeeded);
                    modifiedTotalFuel += fuelNeededForFuel;

                    moduleFuelNeeded = fuelNeededForFuel;
                }
            }

            Console.WriteLine($"The total fuel needed for the modules is : {totalFuel}.");
            Console.WriteLine($"The total fuel needed for the modules and their fuel is : {modifiedTotalFuel}.");
        }

        private int CalculateFuelForModule(int moduleWeight)
        {
            return (moduleWeight / 3) - 2; // Does an integer division, which takes the floor by default
        }

    }
}