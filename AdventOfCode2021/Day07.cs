using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021
{
    
    internal class Day07
    {
        private static string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent + "/Input/Day07/Input.txt";
        public static void One()
        {
            var input = File.ReadAllLines(path)[0].Split(",").Select(x => int.Parse(x));
            var fuel = new int[input.Max()];
            for (int i = 1; i <= input.Max(); i++)
            {
                fuel[i-1] = input.Sum(x => Math.Abs(x - i));;
            }

            Console.WriteLine(fuel.Min());
        }

        public static void Two()
        {
            var input = File.ReadAllLines(path)[0].Split(",").Select(x => int.Parse(x));
            var fuel = new int[input.Max()];
            for (int i = 1; i <= input.Max(); i++)
            {
                fuel[i - 1] = input.Sum(x => ((Math.Abs(x - i) * (Math.Abs(x - i) + 1))/2)) ;
            }

            Console.WriteLine(fuel.Min());
        }
    }
}
