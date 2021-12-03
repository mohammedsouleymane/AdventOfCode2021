using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021
{
    internal class Day3
    {
        public static void One()
        {
            String input;
            List<string> binary = new List<string>();

            while ((input = Console.ReadLine()) != "")
            {
                binary.Add(input);
            }

            string mostFrequent = "";
            string leastFrequent = "";
            for (int i = 0; i < binary[0].Length; i++)
            {
                List<int> numbers = new List<int>();
                for (int j = 0; j < binary.Count; j++)
                {
                    numbers.Add(int.Parse(binary[j][i].ToString()));
                }
                mostFrequent += numbers.GroupBy(n => n).OrderByDescending(g => g.Count()).First().Key;
                leastFrequent += numbers.GroupBy(n => n).OrderBy(g => g.Count()).First().Key;
            }

            Console.WriteLine(Convert.ToInt32(mostFrequent, 2) * Convert.ToInt32(leastFrequent, 2));
        }

        public static void Two()
        {
            String input;
            List<string> binary = new List<string>();

            while ((input = Console.ReadLine()) != "")
            {
                binary.Add(input);
            }

            List<string> oxygenGngRating = new(binary);
            List<string> co2ScrabberRating = new(binary);

            for (int i = 0; i < binary[0].Length; i++)
            {
                string mostFrequent = "";
                string leastFrequent = "";
                List<int> numbers = new List<int>();


                for (int j = 0; j < co2ScrabberRating.Count; j++)
                {
                    numbers.Add(int.Parse(co2ScrabberRating[j][i].ToString()));
                }

                leastFrequent = numbers.GroupBy(n => n).OrderBy(g => g.Count()).First().Key.ToString();
                if (co2ScrabberRating.Count > 1)
                    co2ScrabberRating = co2ScrabberRating.Where(b => b[i] == leastFrequent[0]).ToList();

                numbers = new List<int>();
                for (int j = 0; j < oxygenGngRating.Count; j++)
                {
                    numbers.Add(int.Parse(oxygenGngRating[j][i].ToString()));
                }

                mostFrequent = numbers.GroupBy(n => n).OrderByDescending(g => g.Count()).ThenByDescending(g => g.Key).First().Key.ToString();
                if (oxygenGngRating.Count > 1)
                    oxygenGngRating = oxygenGngRating.Where(b => b[i] == mostFrequent[0]).ToList();
            }

            Console.WriteLine(Convert.ToInt32(oxygenGngRating.First(), 2) * Convert.ToInt32(co2ScrabberRating.First(), 2));
        }
    }
}
