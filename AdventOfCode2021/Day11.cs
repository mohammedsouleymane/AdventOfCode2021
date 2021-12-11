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
                                AdjacentElements(matrix, i, j);
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
                                AdjacentElements(matrix, i, j);
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
        static void AdjacentElements(int[,] arr, int row, int column)
        {
            int rows = arr.GetLength(0);
            int columns = arr.GetLength(1);

            for (int j = row - 1; j <= row + 1; j++)
                for (int i = column - 1; i <= column + 1; i++)
                    if (i >= 0 && j >= 0 && i < columns && j < rows && !(j == row && i == column))
                        if (arr[j, i] != 10 && arr[j, i] > 0)
                            arr[j, i]++;

        }
    }
}