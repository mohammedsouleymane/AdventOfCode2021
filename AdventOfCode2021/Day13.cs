using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021
{
    internal class Day13
    {
        private static string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent + "/Input/Day13/Input.txt";
        public static void OneAndTwo()
        {
            var input = File.ReadAllLines(path);
            var folds = input.Where(x => x.Split(" ")[0] == "fold");
            var maxX = input.Where(x => x.Split(" ")[0] != "fold" && x.Split(" ")[0] != "").Select(x => int.Parse(x.Split(",")[0])).Max();
            var maxY = input.Where(x => x.Split(" ")[0] != "fold" && x.Split(" ")[0] != "").Select(x => int.Parse(x.Split(",")[1])).Max();
            string[,] paper = new string[maxY + 1, maxX + 1];
            
            foreach (var coordinates in input.Where(x => x.Split(" ")[0] != "fold" && x.Split(" ")[0] != ""))
            {
                paper[int.Parse(coordinates.Split(",")[1]), int.Parse(coordinates.Split(",")[0])] = "#";
            }
            //Part One
            var count = 0;
            string[,] PartOne = new string[maxY + 1, maxX + 1];
            foreach (var fold in folds)
            {
                var num = int.Parse(fold.Split(" ")[2].Split("=")[1]);
                if (fold.Split(" ")[2][0] == 'x')
                    PartOne = FoldX(paper, paper.GetLength(0), num);
                else
                    PartOne = FoldY(paper, num, paper.GetLength(0));
                break;
            }
            
            for (int i = 0; i < PartOne.GetLength(0); i++)
            {
                for (int j = 0; j < PartOne.GetLength(1); j++)
                {
                    if (PartOne[i, j] != null)
                        count++;
                }
            }
            Console.WriteLine(count);

            //Part Two
            foreach (var fold in folds)
            {
                var num = int.Parse(fold.Split(" ")[2].Split("=")[1]);
                if (fold.Split(" ")[2][0] == 'x')
                    paper = FoldX(paper, paper.GetLength(0), num);
                else
                    paper = FoldY(paper, num, paper.GetLength(1));
            }
            for (int i = 0; i < paper.GetLength(0); i++)
            {
                for (int j = 0; j < paper.GetLength(1); j++)
                {
                    if (paper[i, j] == "#")
                        Console.Write(" # ");
                    else
                        Console.Write("   ");
                }
                Console.WriteLine();
            }
        }
        private static string[,] FoldY(string[,] paper, int y, int x)
        {
            var combined = new string[y, x];
            for (int i = 0; i < combined.GetLength(0); i++)
            {
                for (int j = 0; j < combined.GetLength(1); j++)
                {
                    string str;
                    try {  str = paper[(y * 2 - i), j]; }
                    catch (Exception) {  str = null; }
                    if (paper[i, j] == "#" || str == "#")
                        combined[i, j] = "#";
                }
            }
            return combined;
        }
        private static string[,] FoldX(string[,] paper, int y, int x)
        {
            var combined = new string[y,x];
            for (int i = 0; i < combined.GetLength(0); i++)
            {
                for (int j = 0; j < combined.GetLength(1); j++)
                {
                    string str;
                    try { str = paper[i, (x * 2 - j)]; }
                    catch (Exception) { str = null; }

                    if (paper[i, j] == "#" || str == "#")
                        combined[i, j] = "#";
                }
            }
            return combined;
        }
    }
}
