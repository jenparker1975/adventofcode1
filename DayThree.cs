using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode1
{
    public static class ListUtils
    {
        public static IEnumerable<IEnumerable<T>> Chunk<T>(this IEnumerable<T> source, int chunksize)
        {
            while (source.Any())
            {
                yield return source.Take(chunksize);
                source = source.Skip(chunksize);
            }
        }
    }
    public class DayThree
    {
        public static void CalculateScore1()
        {
            var lines = File.ReadAllLines(@"D:\source\adventofcode1\rucksack.txt");
            int totalScore = 0;

            foreach (var line in lines)
            { 
                var firstString = line.Substring(0, line.Length / 2);
                var secondString = line.Substring(line.Length / 2);

                var commonItems = firstString.Intersect(secondString).Single().ToString().ToCharArray();
                foreach (var item in commonItems)
                {
                    if (char.IsUpper(item))
                    {
                        totalScore += item - 'A' + 27;
                    }
                    else
                    {
                        totalScore += item - 'a' + 1;
                    }
                }
            }
          
            Console.WriteLine(totalScore);
        }

        public static void CalculateScore2()
        {
            var lines = File.ReadAllLines(@"D:\source\adventofcode1\rucksack.txt");
            int totalScore = 0;

            //chunk up the file into triplets
            var trios = lines.Chunk(3);
            foreach(var trio in trios)
            {
                var trioArr = trio.ToList();
                //find the item common in all 3 lists
                var commonItems = trioArr[0].Intersect(trioArr[1]).Intersect(trioArr[2]).Single().ToString().ToCharArray();
                foreach (var item in commonItems)
                {
                    if (char.IsUpper(item))
                    {
                        totalScore += item - 'A' + 27;
                    }
                    else
                    {
                        totalScore += item - 'a' + 1;
                    }
                }
            }

            Console.WriteLine(totalScore);
        }
    }
}
