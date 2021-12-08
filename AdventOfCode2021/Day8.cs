using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021
{
    internal class Day8

    {
        private static string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent + "/Input/Day8/Input.txt";

        public static void One()
        {
            var input = File.ReadAllLines(path).Select(x => (x.Split("| ")[1]));
            var nums = 0;
            foreach (var item in input)
            {
                nums += item.Split(" ").Select(x => x.Length).Where(x => x == 2 || x == 3 || x == 4 || x == 7).Count();
            }
            Console.WriteLine(nums);
        }


        public static void Two()
        {
            Dictionary<char,char> dic = new();
            string[] numbers = new string[10];
            var input = File.ReadAllLines(path);
            List<int> outputs = new ();
            foreach (var item in input)
            {   
                numbers[1] = item.Split(" |")[0].Split(" ").Where(x => x.Length == 2).ToList()[0];
                numbers[4] = item.Split(" |")[0].Split(" ").Where(x => x.Length == 4).ToList()[0];
                numbers[7] = item.Split(" |")[0].Split(" ").Where(x => x.Length == 3).ToList()[0];
                numbers[8] = item.Split(" |")[0].Split(" ").Where(x => x.Length == 7).ToList()[0];

                foreach (var lengthOf6 in item.Split(" |")[0].Split(" ").Where(x => x.Length == 6).ToList())
                {
                    if(String.Concat((lengthOf6 + numbers[1]).OrderBy(x => x).Distinct()) == String.Concat(numbers[8].OrderBy(x => x)))
                    {
                        numbers[6] = lengthOf6;
                    }
                    else if(String.Concat((lengthOf6 + numbers[4]).OrderBy(x => x).Distinct()) == String.Concat(numbers[8].OrderBy(x => x)))
                    {
                        numbers[0] = lengthOf6;
                    }
                    else
                    {
                        numbers[9] = lengthOf6;
                    }
                }
                foreach (var lengthOf5 in item.Split(" |")[0].Split(" ").Where(x => x.Length == 5).ToList())
                {
                    if (String.Concat((lengthOf5 + numbers[1]).OrderBy(x => x).Distinct()) == String.Concat(numbers[9].OrderBy(x => x)))
                    {
                        numbers[5] = lengthOf5;
                    }
                    else if(String.Concat((lengthOf5 + numbers[1]).OrderBy(x => x).Distinct()).Length == 6)
                    {
                        numbers[2] = lengthOf5;
                    }
                    else
                        numbers[3] = lengthOf5;
                }
                string output = "";
                numbers = numbers.Select(x => String.Concat(x.OrderBy(c => c))).ToArray();
                foreach (var i in item.Split("| ")[1].Split(" "))
                {
                    output += Array.IndexOf(numbers, String.Concat(i.OrderBy(c => c)));
                   
                }

                outputs.Add(int.Parse(output));

            }

            Console.WriteLine(outputs.Sum());
        }
    }
}
