using AdventOfCode.Days;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace AdventOfCode.Years._2015.Days
{
    public class Day7 : IPuzzleDay
    {
        public void Run(string path)
        {
            var list = FileReader.ReadLineToStringList(path);

            var formattedInstructions = FormatInstructions(list);
            _instructions = formattedInstructions;

            //var expression = GetExpressions();

            var listOfWires = GetListOfWires(formattedInstructions);

            //var answer = this.CalculateAnswerValue(formattedInstructions, listOfWires);
            //var noLogicInstructions = formattedInstructions.Where(x => x.LogicOperator.Equals(string.Empty));

            // x = 5;
            // y = x;
            // z = x + y;

            ushort val = 5;
            var x = Expression.Constant(val);
            var y = x;
            var z = Expression.Add(x, y);
            var answer = Expression.Lambda<Func<ushort>>(z).Compile()();

            Console.WriteLine($"The signal ultimately provided to wire \"a\" is : {answer}.");
        }

        private List<Instruction> _instructions = new List<Instruction>();
        private Dictionary<string, Expression> _expressions = new Dictionary<string, Expression>();

        private Expression GetExpression(Instruction instruction)
        {
            switch (instruction.LogicOperator)
            {
                case "AND":
                {
                    var left = GetOperand(instruction.LeftValue.Name);
                    var right = GetOperand(instruction.RightValue.Name);
                    return Expression.And(left, right);
                }
                case "NOT":
                {
                    var right = GetOperand(instruction.RightValue.Name);
                    return Expression.Not(right);
                }
                case "OR":
                {
                    var left = GetOperand(instruction.LeftValue.Name);
                    var right = GetOperand(instruction.RightValue.Name);
                    return Expression.Or(left, right);
                }
                case "LSHIFT":
                {
                    var left = GetOperand(instruction.LeftValue.Name);
                    var right = GetOperand(instruction.RightValue.Name);
                    return Expression.LeftShift(left, right);
                }
                case "RSHIFT":
                {
                    var left = GetOperand(instruction.LeftValue.Name);
                    var right = GetOperand(instruction.RightValue.Name);
                    return Expression.RightShift(left, right);
                }
                case "":
                {
                    return GetOperand(instruction.RightValue.Name);
                }
                default:
                    throw new Exception();
            }

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
        }

        private Expression GetOperand(string text)
        {
            if(ushort.TryParse(text, out var value))
            {
                return Expression.Constant(value);
            }
            else if (_expressions.ContainsKey(text))
            {
                return _expressions[text];
            }
            else
            {
                return Expression.Empty();
            }
        }

        private List<Instruction> FormatInstructions(List<string> inputList)
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

        private List<CircuitComponent> GetListOfWires(List<Instruction> listOfInstructions)
        {
            List<CircuitComponent> wires = new List<CircuitComponent>();

            foreach (var item in listOfInstructions)
            {
                CircuitComponent wire = new CircuitComponent(item.AnswerValue.Name);

                wires.Add(wire);
            }

            return wires.Distinct().ToList();
        }

        private UInt16? CalculateAnswerValue(List<Instruction> listOfInstructions, List<CircuitComponent> listOfWires)
        {
            //do some recursion in here until I evaluate enough to get the answer.

            var targetWire = listOfInstructions.First(x => x.AnswerValue.Name.Equals("a"));

            if (targetWire.AnswerValue.Value != null)
                return targetWire.AnswerValue.Value;

            return CalculateAnswerValue(listOfInstructions, listOfWires);




            //need to work out what I'm doing with this block with regards to the answer.
            //also need to cast to UInt32, then cast the answer back to UInt16

            //Need to handle instruction._value.Name being "", and ignoring it from calculating the answer

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

        private class Instruction
        {
            internal Instruction(string fullInput, CircuitComponent left, string logicOp, CircuitComponent right, CircuitComponent answer)
            {
                FullInput = fullInput;

                LeftValue = left;
                LogicOperator = logicOp;
                RightValue = right;
                AnswerValue = answer;
            }

            internal string FullInput { get; }

            internal CircuitComponent LeftValue { get; }

            internal string LogicOperator { get; }

            internal CircuitComponent RightValue { get; }

            internal CircuitComponent AnswerValue { get; set; }
        }

        private class CircuitComponent
        {
            internal CircuitComponent(string name)
            {
                Name = name;

                if (UInt16.TryParse(name, out UInt16 result))
                {
                    Value = result;
                }
            }

            internal string Name { get; }

            internal UInt16? Value { get; set; }
        }
    }
}
