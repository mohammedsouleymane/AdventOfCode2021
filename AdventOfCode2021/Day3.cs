using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021
{
    internal class Day3
    {
        private static string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent + "/Input/Day3/Input.txt";
        public static void One()
        {
            var binary = File.ReadAllLines(path).ToList();
            string mostFrequent = "";
            string leastFrequent = "";
            for (int i = 0; i < binary[0].Length; i++)
            {
                List<int> numbers = binary.Select(x => int.Parse(x[i].ToString())).ToList();
                mostFrequent += numbers
                    .GroupBy(n => n)
                    .OrderByDescending(g => g.Count())
                    .First().Key;
                leastFrequent += numbers
                    .GroupBy(n => n)
                    .OrderBy(g => g.Count())
                    .First().Key;
            }

            Console.WriteLine(Convert.ToInt32(mostFrequent, 2) * Convert.ToInt32(leastFrequent, 2));
        }

        public static void Two()
        {
            var binary = File.ReadAllLines(path).ToList();
            List<string> oxygenGngRating = new(binary);
            List<string> co2ScrabberRating = new(binary);

            for (int i = 0; i < binary[0].Length; i++)
            {
                List<int> numbers = co2ScrabberRating
                    .Select(x => int.Parse(x[i].ToString()))
                    .ToList();
                string leastFrequent = numbers
                    .GroupBy(n => n)
                    .OrderBy(g => g.Count())
                    .First().Key.ToString();

                if (co2ScrabberRating.Count > 1)
                    co2ScrabberRating = co2ScrabberRating.Where(b => b[i] == leastFrequent[0]).ToList();

                numbers = oxygenGngRating
                    .Select(x => int.Parse(x[i].ToString()))
                    .ToList();

                string mostFrequent = numbers
                    .GroupBy(n => n)
                    .OrderByDescending(g => g.Count())
                    .ThenByDescending(g => g.Key)
                    .First().Key.ToString();

                if (oxygenGngRating.Count > 1)
                    oxygenGngRating = oxygenGngRating.Where(b => b[i] == mostFrequent[0]).ToList();
            }

            Console.WriteLine(Convert.ToInt32(oxygenGngRating.First(), 2) * Convert.ToInt32(co2ScrabberRating.First(), 2));
        }
    }
}
