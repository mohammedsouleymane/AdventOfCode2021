using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021
{
    internal class Day06
    {
        private static string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent + "/Input/Day06/Input.txt";
        public static void One()
        {
            var input = "3,4,3,1,2".Split(",").Select(x => int.Parse(x)).ToList();
            var days = 80;
            for (int i = 0; i < days; i++)
            {
                int add = 0;
                for (int j = 0; j < input.Count; j++)
                {
                    if (input[j] == 0)
                    {
                        input[j] = 6;
                        add++;
                    }
                    else
                        input[j] = --input[j];
                }
                if (add > 0)
                {
                    for (int k = 0; k < add; k++)
                    {
                        input.Add(8);
                    }
                }

            }
            Console.WriteLine(input.Count);
        }

        public static void Two()
        {

            var days = 18;
            var input = new long[9];
            foreach (var ch in File.ReadAllLines(path)[0].Split(","))
            {
                input[int.Parse(ch)]++;

            }
            for (var t = 0; t < days; t++)
            {
               
                input[(t + 7) % 9] += input[t % 9];
            }

            Console.WriteLine(input.Sum());
        }
    }
    }

