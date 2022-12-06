using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode1
{
    public class DaySix
    {
        int SolvePart1(string input)
            => Enumerable.Range(4, input.Length).First(i => input[(i - 4)..i].Distinct().Count() == 4);


        int SolvePart2(string input)
            => Enumerable.Range(14, input.Length).First(i => input[(i - 14)..i].Distinct().Count() == 14);

        public void GetMarker()
        {
            var lines = File.ReadAllText(@"D:\source\adventofcode1\packets.txt");
            var part1 = SolvePart1(lines);
            Console.WriteLine(part1);

            var part2 = SolvePart2(lines);
            Console.WriteLine(part2);

        }
    }
}
