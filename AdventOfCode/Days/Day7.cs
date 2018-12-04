using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode.Days
{
    public class Day7 : IPuzzleDay
    {
        public void Run(string path)
        {
            var list = FileReader.ReadLineToStringList(path);

            var formattedInstructions = this.FormatInstructions(list);

            var answer = this.CalculateAnswerValue(formattedInstructions.First(x => x.AnswerValue.Name.Equals("a")));
            //var noLogicInstructions = formattedInstructions.Where(x => x.LogicOperator.Equals(string.Empty));

            Console.WriteLine($"The signal ultimately provided to wire \"a\" is : {answer}.");
        }

        internal List<Instruction> FormatInstructions(List<string> inputList)
        {
            List<Instruction> instructions = new List<Instruction>();

            foreach (var line in inputList)
            {
                var rgx = @"(?-i)(?<leftValue>[a-z0-9]*)?? ?(?<logicOperator>RSHIFT|LSHIFT|OR|NOT|AND)?? ?(?<rightValue>[a-z0-9]*)?? ?-> (?<answerValue>[a-z0-9]*)";

                var matches = Regex.Match(line, rgx).Groups;

                CircuitComponent left = new CircuitComponent(matches["leftValue"].Value);
                string logic = matches["logicOperator"].Value;
                CircuitComponent right = new CircuitComponent(matches["rightValue"].Value);
                CircuitComponent answer = new CircuitComponent(matches["answerValue"].Value);


                Instruction instruction = new Instruction(line, left, logic, right, answer);

                instructions.Add(instruction);
            }

            return instructions;
        }

        internal UInt16? CalculateAnswerValue(Instruction instruction)
        {
            //do some recursion in here until I evaluate enough to get the answer.

            if (instruction.AnswerValue.Value != null)
                return instruction.AnswerValue.Value;

            //need to work out what I'm doing with this block with regards to the answer.
            //also need to cast to UInt32, then cast the answer back to UInt16

            //if (instruction.Equals("AND"))
            //    z = x & y;
            //else if (instruction.Equals("NOT"))
            //    z = ~x;
            //else if (instruction.Equals("OR"))
            //    z = x | y;
            //else if (instruction.Equals("LSHIFT"))
            //    z = x << y;
            //else if (instruction.Equals("RSHIFT"))
            //    z = x >> y;

            return 0;
        }

        internal class Instruction
        {
            internal Instruction(string fullInput, CircuitComponent left, string logicOp, CircuitComponent right, CircuitComponent answer)
            {
                this.FullInput = fullInput;

                this.LeftValue = left;
                this.LogicOperator = logicOp;
                this.RightValue = right;
                this.AnswerValue = answer;
            }

            internal string FullInput { get; }

            internal CircuitComponent LeftValue { get; }

            internal string LogicOperator { get; }

            internal CircuitComponent RightValue { get; }

            internal CircuitComponent AnswerValue { get; set; }
        }

        internal class CircuitComponent
        {
            internal CircuitComponent(string name)
            {
                this.Name = name;

                if (UInt16.TryParse(name, out UInt16 result))
                {
                    this.Value = result;
                }
            }

            internal string Name { get; }

            internal UInt16? Value { get; set; }
        }
    }
}
