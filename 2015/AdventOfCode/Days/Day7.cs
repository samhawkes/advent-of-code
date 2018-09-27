using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Days
{
    public class Day7 : IPuzzleDay
    {
        public void Run(string path)
        {
            var list = FileReader.ReadLineToStringList(path);

            /*Idea dump
             * Class that contains the left hand side - which variables and which operator
             * Something that contains the right hand side
             * When trying to evaluate the left, look up what creates it from the right and work backwards 
             */



            foreach (var instruction in list)
            {
                UInt16 x = 0;
                UInt16 y = 0;
                UInt16 z = 0;

                if (instruction.Contains(LogicActions.AND.ToString()))
                    z = x & y;
                else if (instruction.Contains(LogicActions.NOT.ToString()))
                    z = ~x;
                else if (instruction.Contains(LogicActions.OR.ToString()))
                    z = x | y;
                else if (instruction.Contains(LogicActions.LSHIFT.ToString()))
                    z = x << y;
                else if (instruction.Contains(LogicActions.RSHIFT.ToString()))
                    z = x >> y;
            }


        }

        private enum LogicActions
        {
            AND,
            NOT,
            OR,
            LSHIFT,
            RSHIFT
        }
    }
}
