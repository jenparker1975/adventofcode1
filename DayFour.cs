using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode1
{
 
    public class DayFour
    {
        public static void CalculateScore1()
        {
            var lines = File.ReadAllLines(@"D:\source\adventofcode1\cleaningpairs.txt");
            var partialOverlap = 0;
            var fullOverlap = 0;

            foreach (var line in lines)
            {
                var pairSplits = line.Split(',');
                var rangeSplits = pairSplits[0].Split('-');
                var firstElfList = Enumerable.Range(int.Parse(rangeSplits[0]), int.Parse(rangeSplits[1]) - int.Parse(rangeSplits[0]) + 1).ToList();

                rangeSplits = pairSplits[1].Split('-');
                var secondElfList = Enumerable.Range(int.Parse(rangeSplits[0]), int.Parse(rangeSplits[1]) - int.Parse(rangeSplits[0]) + 1).ToList();

                if (firstElfList.Any(x => secondElfList.Any(y => y == x)) || secondElfList.Any(x => firstElfList.Any(y => y == x)))
                {
                    partialOverlap += 1;
                }

                if (firstElfList.All(x => secondElfList.Any(y => y == x)) || secondElfList.All(x => firstElfList.Any(y => y == x)))
                {
                    fullOverlap += 1;
                }
            }
          
            Console.WriteLine(fullOverlap);
            Console.WriteLine(partialOverlap);
        }
    }
}
