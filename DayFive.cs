using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode1
{
    public struct Instructions
    {
        public Instructions(string instructions)
        {
            var moves = instructions.Trim().Split(' ');
            NumberOfCratesToMove = int.Parse(moves[1]);
            FromStack = int.Parse(moves[3]) - 1;
            ToStack = int.Parse(moves[5]) - 1;
        }

        public int NumberOfCratesToMove { get; set; }
        public int FromStack { get; }
        public int ToStack { get; }
    }

    public class DayFive
    {
        public static void CalculateScore1()
        {
            var cratesAndInstructions = GetCratesAndInstructions();

            var cratesToRearrange = cratesAndInstructions.Item1;
            var instructions = cratesAndInstructions.Item2;
            foreach (var instruction in instructions)
            {
                var numberToMove = instruction.NumberOfCratesToMove;
                while (numberToMove > 0)
                {
                    var crate = cratesToRearrange[instruction.FromStack].Pop();
                    cratesToRearrange[instruction.ToStack].Push(crate);
                    numberToMove--;
                }
            }

            var crateStr = new StringBuilder();
            foreach (var stack in cratesToRearrange)
            {
                crateStr.Append(stack.Peek());
            }
            Console.WriteLine(crateStr);

        }

        public static void CalculateScore2()
        {
            var cratesAndInstructions = GetCratesAndInstructions();

            var cratesToRearrange = cratesAndInstructions.Item1;
            var instructions = cratesAndInstructions.Item2;

            foreach (var instruction in instructions)
            {
                var miniStack = new Stack<string>();
                var numberToMove = instruction.NumberOfCratesToMove;

                while (numberToMove > 0)
                {
                    var crate = cratesToRearrange[instruction.FromStack].Pop();
                    miniStack.Push(crate);
                    numberToMove--;
                }

                while (miniStack.Any())
                {
                    var crate = miniStack.Pop();
                    cratesToRearrange[instruction.ToStack].Push(crate);
                }
            }

            var crateStr = new StringBuilder();
            foreach (var stack in cratesToRearrange)
            {
                crateStr.Append(stack.Peek());
            }
            Console.WriteLine(crateStr);

        }

        private static Tuple<List<Stack<string>>, List<Instructions>> GetCratesAndInstructions()
        {
            var lines = File.ReadAllLines(@"D:\source\adventofcode1\crates.txt");
            var cratesToRearrange = new List<Stack<string>>();
            var crateStr = new List<string>();
            var instructions = new List<Instructions>();

            foreach (var line in lines)
            {
                if (line.StartsWith("["))
                {
                    crateStr.Add(line);
                }
                else if (line.StartsWith("move"))
                {
                    instructions.Add(new Instructions(line));
                }
            }

            for (var i = 0; i <= crateStr.Count; i++)
            {
                var stack = new Stack<string>();
                cratesToRearrange.Add(stack);
            }
            
            for (var i = crateStr.Count - 1; i >= 0; i--)
            {
                var stackNumber = 0;
                for (var j = 1; j <= crateStr[i].Length; j += 4)
                {
                    var crate = crateStr[i].Substring(j, 1);
                    if (!string.IsNullOrWhiteSpace(crate))
                    {
                        cratesToRearrange[stackNumber].Push(crate);
                    }

                    stackNumber++;
                }
            }

            return new Tuple<List<Stack<string>>, List<Instructions>>(cratesToRearrange, instructions);
        }
    }
}
