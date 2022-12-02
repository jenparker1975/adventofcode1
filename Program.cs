using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode1
{
    class Program
    {
        static void Main(string[] args)
        {
            Day2B();
        }

        static void Day2()
        {
            var lines = File.ReadAllLines(@"D:\source\adventofcode1\rockpaperscissors.txt");            
            int totalScore = 0;            
            foreach (var line in lines)
            {
                var chars = line.ToCharArray();
               
                switch(chars[0])
                {
                    //opponent picks Rock
                    case 'A':
                        if (chars[2] == 'X') //rock
                        {
                            totalScore += 1 + 3;
                        }
                        else if (chars[2] == 'Y') //paper
                        {
                            totalScore += 2 + 6;
                        }
                        else //scissors
                        {
                            totalScore += 3 + 0; 
                        }

                        break;

                    //opponent picks Paper
                    case 'B':
                        if (chars[2] == 'X') //rock
                        {
                            totalScore += 1 + 0;
                        }
                        else if (chars[2] == 'Y') //paper
                        {
                            totalScore += 2 + 3;
                        }
                        else //scissors
                        {
                            totalScore += 3 + 6; 
                        }
                        break;
;

                    //opponent picks scissors
                    case 'C':
                        if (chars[2] == 'X') //rock
                        {
                            totalScore += 1 + 6;
                        }
                        else if (chars[2] == 'Y') //paper
                        {
                            totalScore += 2 + 0;
                        }
                        else //scissors
                        {
                            totalScore += 3 + 3;
                        }

                        break;
                }                
            }
            Console.WriteLine(totalScore);
        }

        static void Day2B()
        {
            var lines = File.ReadAllLines(@"D:\source\adventofcode1\rockpaperscissors.txt");            
            int totalScore = 0;
            foreach (var line in lines)
            {
                var chars = line.ToCharArray();

                switch (chars[0])
                {
                    //opponent picks Rock
                    case 'A':
                        if (chars[2] == 'X') //I need to lose, so I pick scissors
                        {
                            totalScore += 3 + 0;
                        }
                        else if (chars[2] == 'Y') //I need a drawer, so I pick rock
                        {
                            totalScore += 1 + 3;
                        }
                        else //I need to win so I pick paper
                        {
                            totalScore += 2 + 6;
                        }

                        break;

                    //opponent picks Paper
                    case 'B':
                        if (chars[2] == 'X') //I need to lose, so I pick rock
                        {
                            totalScore += 1 + 0;
                        }
                        else if (chars[2] == 'Y') //I need a drawer so I pick paper
                        {
                            totalScore += 2 + 3;
                        }
                        else //I need to win so I pick scissors
                        {
                            totalScore += 3 + 6;
                        }
                        break;
                        ;

                    //opponent picks scissors
                    case 'C':
                        if (chars[2] == 'X') //I need to lose, so I pick paper
                        {
                            totalScore += 2 + 0;
                        }
                        else if (chars[2] == 'Y') //I need a drawer so I pick scissors
                        {
                            totalScore += 3 + 3;
                        }
                        else //I need to win so I pick rock
                        {
                            totalScore += 1 + 6;
                        }

                        break;
                }
            }
            Console.WriteLine(totalScore);
        }

        static void Day1()
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
