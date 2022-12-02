using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode1
{
    public class DayOne
    {
        public static void CalculateCalories()
        {
            var elvesAndCalories = new Dictionary<int, int>();
            var elf = 1;

            var lines = File.ReadAllLines(@"D:\source\adventofcode1\elves.txt");
            elvesAndCalories.Add(elf, 0);

            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    elf++;
                    elvesAndCalories.Add(elf, 0);
                    continue;
                }

                if (!int.TryParse(line, out int calories))
                    continue;

                elvesAndCalories[elf] += calories;
            }

            var elfWithMost = elvesAndCalories.OrderByDescending(x => x.Value).FirstOrDefault().Key;
            Console.WriteLine("{0} elf had {1} calories", elfWithMost, elvesAndCalories[elfWithMost]);


            Console.WriteLine(elvesAndCalories.OrderByDescending(x => x.Value).Take(3).Sum(s => s.Value));
        }
    }
}
