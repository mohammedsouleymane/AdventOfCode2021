using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
namespace AdventOfCode2021
{
    class Day1
    {
       public static void One()
        {
            List<int> list = new();
            string input = "";
            while ((input = Console.ReadLine()) != "")
            {
                list.Add(int.Parse(input.Split(" ")[0]));
            }

            Console.WriteLine(Enumerable.Range(1, list.Count - 1).Where(i => list[i] > list[i - 1]).ToList().Count);
        }

        public static void Two()
        {
            List<int> list = new();
            string input = "";
            while ((input = Console.ReadLine()) != "")
            {
                list.Add(int.Parse(input.Split(" ")[0]));
            }

            List<int> result = new();

            for (int i = 0; i < list.Count - 2; i++)
            {
                if (list.Count > i + 1 && list.Count > i + 2)
                    result.Add(list[i] + list[i + 1] + list[i + 2]);
            }

            Console.WriteLine(Enumerable.Range(1, result.Count - 1).Where(i => result[i] > result[i - 1]).ToList().Count);
        }
    }
}
