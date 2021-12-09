using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021
{
    internal class Day9
    {
        private static string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent + "/Input/Day9/Input.txt";
        public static void One()
        {
            var input = File.ReadAllLines(path);

            var matrix = new int[input.Count(), input[0].Length];
            var lows = new List<int>();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = int.Parse(input[i][j].ToString());
                }
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    int up = 10;
                    int down = 10;
                    int right = 10;
                    int left = 10;


                    if (i > 0)
                        up = matrix[i - 1, j];
                    if (i < matrix.GetLength(0) - 1)
                        down = matrix[i + 1, j];
                    if (j > 0)
                        left = matrix[i, j - 1];
                    if (j < matrix.GetLength(1) - 1)
                        right = matrix[i, j + 1];

                    if (matrix[i, j] < up && matrix[i, j] < down && matrix[i, j] < left && matrix[i, j] < right)
                    {
                        lows.Add(matrix[i, j]);
                    }

                }
            }
            Console.WriteLine(lows.Sum() + lows.Count());
        }

        public static void Two()
        {
            var input = File.ReadAllLines(path);

            var matrix = new int[input.Count(), input[0].Length];
            var bassins = new List<int>();
            
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = int.Parse(input[i][j].ToString());
                }
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    int up = 10;
                    int down = 10;
                    int right = 10;
                    int left = 10;

                    if (i > 0)
                        up = matrix[i - 1, j];
                    if (i < matrix.GetLength(0) - 1)
                        down = matrix[i + 1, j];
                    if (j > 0)
                        left = matrix[i, j - 1];
                    if (j < matrix.GetLength(1) - 1)
                        right = matrix[i, j + 1];

                    if (matrix[i, j] < up && matrix[i, j] < down && matrix[i, j] < left && matrix[i, j] < right)
                    {
                        bassins.Add(BassinSize(matrix, i, j));
                    }

                }
                bassins.Sort();
                bassins.Reverse();
            }
            Console.WriteLine(bassins[0] * bassins[1] * bassins[2]);
        }

        private static int BassinSize(int[,] matrix, int y, int x)
        {
            if (matrix[y, x] == 9)
                return 0;
            matrix[y, x] = -1;
            int sum = 1;
            if (x > 0 && matrix[y, x - 1] > -1 && matrix[y, x - 1] < 9)
                sum += BassinSize(matrix, y, x - 1);
            

            if (y > 0 && matrix[y - 1, x] > -1 && matrix[y - 1, x] < 9)
                sum += BassinSize(matrix, y - 1, x);
            

            if (y < matrix.GetLength(0) - 1 && matrix[y + 1, x] > -1 && matrix[y + 1, x] < 9)
                sum  += BassinSize(matrix, y + 1, x);
            


            if (x < matrix.GetLength(1) - 1 && matrix[y, x + 1] > -1 && matrix[y, x + 1] < 9)
                sum += BassinSize(matrix, y, x + 1);
            
           

            return  sum;
        }


    }
}
