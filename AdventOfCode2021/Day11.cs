using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021
{
    internal class Day11
    {
        private static string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent + "/Input/Day11/Input.txt";

        public static void One()
        {


            var input = File.ReadAllLines(path);
            var matrix = new int[input.Length, input[0].Length];
            var flashes = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = int.Parse(input[i][j].ToString());
                }
            }
            for (int o = 0; o < 100; o++)
            {

                HashSet<string> set = new HashSet<string>();
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        ++matrix[i, j];
                    }
                }
                var t = -1;
                while (t != flashes)
                {
                    t = flashes;
                    for (int i = 0; i < matrix.GetLength(0); i++)
                    {
                        for (int j = 0; j < matrix.GetLength(1); j++)
                        {
                            if (matrix[i, j] % 10 == 0 && !set.Contains(j + "," + i))
                            {
                                CheckFlashes(matrix, i, j);
                                flashes++;
                                set.Add(j + "," + i);
                                matrix[i, j] = 0;
                            }


                        }
                    }
                }
            }
            Console.WriteLine(flashes);
        }
        public static void Two()
        {
            var input = File.ReadAllLines(path);
            var matrix = new int[input.Length, input[0].Length];
            var flashes = 0;

            var list = new List<int>();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = int.Parse(input[i][j].ToString());
                    list.Add(matrix[i, j]);
                }
            }
            var sync = list.GroupBy(x => x).Count() == 1;
            var step = -1;
            while (!sync)
            {
                step++;
                HashSet<string> set = new HashSet<string>();
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        ++matrix[i, j];
                    }
                }
                var t = -1;
                list = new List<int>();
                while (t != flashes)
                {
                    t = flashes;
                    for (int i = 0; i < matrix.GetLength(0); i++)
                    {
                        for (int j = 0; j < matrix.GetLength(1); j++)
                        {
                            if (matrix[i, j] % 10 == 0 && !set.Contains(j + "," + i))
                            {
                                CheckFlashes(matrix, i, j);
                                flashes++;
                                set.Add(j + "," + i);
                                matrix[i, j] = 0;
                            }
                            list.Add(matrix[i, j]);
                        }
                    }
                }
                sync = list.GroupBy(x => x).Count() == 1;

            }

            Console.WriteLine(step);
        }
        private static void CheckFlashes(int[,] matrix, int y, int x)
        {
            if (y > 0)
            {
                if (matrix[y - 1, x] != 10 && matrix[y - 1, x] > 0)
                    matrix[y - 1, x]++;
            }

            if (y < matrix.GetLength(0) - 1)
            {
                if (matrix[y + 1, x] != 10 && matrix[y + 1, x] > 0)
                    matrix[y + 1, x]++;
            }
            if (x > 0)
            {
                if (matrix[y, x - 1] != 10 && matrix[y, x - 1] > 0)
                    matrix[y, x - 1]++;
            }

            if (x < matrix.GetLength(1) - 1)
            {
                if (matrix[y, x + 1] != 10 && matrix[y, x + 1] > 0)
                    matrix[y, x + 1]++;
            }
            if (y < matrix.GetLength(0) - 1 && x < matrix.GetLength(1) - 1)
            {
                if (matrix[y + 1, x + 1] != 10 && matrix[y + 1, x + 1] > 0)
                    matrix[y + 1, x + 1]++;
            }
            if (y > 0 && x > 0)
            {
                if (matrix[y - 1, x - 1] != 10 && matrix[y - 1, x - 1] > 0)
                    matrix[y - 1, x - 1]++;
            }

            if (y < matrix.GetLength(0) - 1 && x > 0)
            {
                if (matrix[y + 1, x - 1] != 10 && matrix[y + 1, x - 1] > 0)
                    matrix[y + 1, x - 1]++;
            }
            if (y > 0 && x < matrix.GetLength(1) - 1)
            {
                if (matrix[y - 1, x + 1] != 10 && matrix[y - 1, x + 1] > 0)
                    matrix[y - 1, x + 1]++;
            }
        }

    }
}