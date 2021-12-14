using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021
{
    internal class Day14
    {
        private static string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent + "/Input/Day14/Input.txt";

        public static void One()
        {
            var input = File.ReadAllLines(path);
            var template = input[0];

            var rules = new Dictionary<string, string>();

            foreach (var rule in input.Where(x => Array.IndexOf(input, x) > 1).ToArray())
            {
                rules.Add(rule.Split(" -> ")[0], rule.Split(" -> ")[1]);
            }


            for (int i = 0; i < 10; i++)
            {
                var str = template[0].ToString();
                for (int j = 0; j < template.ToCharArray().Length - 1; j++)
                {
                    var pair = template.Substring(j, 2);
                    try
                    {
                        str += rules[pair] + pair[1];
                    }
                    catch (Exception)
                    {
                        str += pair[1];
                    }
                }
                template = str;
            }

            var result = template.GroupBy(x => x).Max(x => x.Count()) - template.GroupBy(x => x).Min(x => x.Count());
            Console.WriteLine(result);
        }

        public static void Two()
        {
            var input = File.ReadAllLines(path);
            var template = input[0];
            var rules = new Dictionary<string, string>();
            var singles = template.GroupBy(x => x).ToDictionary(y => y.Key, y => (long)y.Count());
            var pairs = new Dictionary<string, long>();

            foreach (var rule in input.Where(x => Array.IndexOf(input, x) > 1).ToArray())
            {
                rules.Add(rule.Split(" -> ")[0], rule.Split(" -> ")[1]);
            }

            for (int i = 0; i < template.Length - 1; i++)
            {
                if (pairs.ContainsKey(template[i].ToString() + template[i + 1]))
                {
                    pairs[template[i].ToString() + template[i + 1]]++;
                }
                else
                    pairs.Add((template[i].ToString() + template[i + 1]), 1);
            }

            for (int i = 0; i < 40; i++)
            {
                foreach (var pair in pairs)
                {
                    if (singles.ContainsKey(rules[pair.Key][0]))
                        singles[rules[pair.Key][0]] += pair.Value;
                    else
                        singles.Add(rules[pair.Key][0], 1);
                }
                pairs = NewPairs(rules, pairs);
            }
            Console.WriteLine(singles.Max(x => x.Value) - singles.Min(x => x.Value));
        }


        private static Dictionary<string, long> NewPairs(Dictionary<string, string> rules, Dictionary<string, long> pairs)
        {
            var pairsNew = new Dictionary<string, long>();
            foreach (var pair in pairs)
            {
                var one = pair.Key[0].ToString() + rules[pair.Key][0];
                var two = rules[pair.Key][0].ToString() + pair.Key[1];

                if (pairsNew.ContainsKey(one))
                    pairsNew[one] += pair.Value;
                else
                    pairsNew.Add(one, pair.Value);

                if (pairsNew.ContainsKey(two))
                    pairsNew[two] += pair.Value;
                else
                    pairsNew.Add(two, pair.Value);
            }
            return pairsNew;
        }
    }
}
