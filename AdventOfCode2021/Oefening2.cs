using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021
{
    internal class Oefening2
    {

        public static void One()
        {

            String input;
            int forward = 0;
            int depth = 0;

            while ((input = Console.ReadLine()) != "")
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
            String input;
            int forward = 0;
            int depth = 0;
            int aim = 0;
            while ((input = Console.ReadLine()) != "")
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
