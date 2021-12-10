using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021
{
    internal class Day02
    {
        private static string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent + "/Input/Day02/Input.txt";
        public static void One()
        {
            int forward = 0;
            int depth = 0;
            foreach (var input in File.ReadAllLines(path))
            {

                int number = int.Parse(input.Split(" ")[1]);
                if (input.Contains("forward"))
                    forward += number;
                else if (input.Contains("down"))
                    depth += number;
                else
                    depth -= number;
            }
            Console.WriteLine(depth * forward);
        }

        public static void Two()
        {
            int forward = 0;
            int depth = 0;
            int aim = 0;
            foreach (var input in File.ReadAllLines(path))
            {
                int number = int.Parse(input.Split(" ")[1]);
                if (input.Contains("forward"))
                {
                    forward += number;
                    depth += aim * number;
                }
                else if (input.Contains("down"))
                    aim += number;
                else
                    aim -= number;
            }
            Console.WriteLine(depth * forward);
        }
    }
}
