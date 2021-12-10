using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021
{
    internal class Day10
    {
        private static string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent + "/Input/Day10/Input.txt";

        public static void One()
        {
            var input = File.ReadAllLines(path);
            var points = new Dictionary<char, int>() { { ')', 3 }, { ']', 57 }, { '}', 1197 }, { '>', 25137 } };
            var pairs = new Dictionary<char, char>() { { '(', ')' }, { '[', ']' }, { '{', '}' }, { '<', '>' } };
            var incorrectChars = new List<char>();
            foreach (var chunk in input)
            {
                Stack<char> open = new Stack<char>();
                foreach (var ch in chunk)
                {

                    if (!points.ContainsKey(ch))
                        open.Push(ch);
                    else
                    {
                        if (ch != pairs[open.Pop()])
                        {
                            incorrectChars.Add(ch);
                            break;
                        }
                    }

                }
            }
            Console.WriteLine(incorrectChars.Select(x => points[x]).ToArray().Sum());
        }

        public static void Two()
        {
            var input = File.ReadAllLines(path);
            var points = new Dictionary<char, int>() { { ')', 1 }, { ']', 2 }, { '}', 3 }, { '>', 4 } };
            var pairs = new Dictionary<char, char>() { { '(', ')' }, { '[', ']' }, { '{', '}' }, { '<', '>' } };
            var charsToCompletePoints = new List<long>();
            foreach (var chunk in input)
            {
                Stack<char> open = new();
                bool incomplete = true;
                foreach (var ch in chunk)
                {

                    if (!points.ContainsKey(ch))
                        open.Push(ch);
                    else
                    {
                        if (ch != pairs[open.Pop()])
                        {
                            incomplete = false;
                        }
                    }
                }
                if (incomplete)
                {
                    long totalPoints = 0;
                    foreach (var item in open)
                    {
                        totalPoints = (totalPoints * 5) + points[pairs[item]];
                    }
                    charsToCompletePoints.Add(totalPoints);
                }
            }
            charsToCompletePoints.Sort();
            Console.WriteLine(charsToCompletePoints.Skip(charsToCompletePoints.Count / 2).First());
        }
    }
}
