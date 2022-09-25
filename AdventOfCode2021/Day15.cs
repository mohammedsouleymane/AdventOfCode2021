using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021
{
    internal class Day15
    {
        static string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent + "/Input/Day15/Input.txt";
        static SortedSet<(int p, int x, int y)> costs = new();
        static SortedSet<(int, int)> visited = new();
        public static void One()
        {
            var input = File.ReadAllLines(path);
            var matrix = Wrap(input);
        

            (int x, int y) coordinate = (0, 0);
            foreach (var c in CollectionsMarshal.AsSpan(GetNeighbors((0, 0), matrix)))
            {
                costs.Add((matrix[c.x, c.y], c.x, c.y));
            }
            visited.Add(coordinate);
            while (coordinate != (matrix.GetLength(0) - 1, matrix.GetLength(1) - 1))
            {
                coordinate = (costs.First().x, costs.First().y);
                visited.Add(coordinate);
                foreach (var c in GetNeighbors(coordinate, matrix).Where(x => !visited.Contains(x)))
                {
                        costs.Add((matrix[c.x, c.y] + costs.First().p, c.x, c.y));
                }
                costs.Remove(costs.First());
            }
            Console.WriteLine(costs.First().p - matrix[0,0]);
        }


        static List<(int x, int y)> GetNeighbors((int x, int y) coordinates, int[,] matrix)
        {
            List<(int x, int y)> neighbors = new();

            if (coordinates.x > 0)
                neighbors.Add((coordinates.x - 1, coordinates.y));

            if (coordinates.y > 0)
                neighbors.Add((coordinates.x, coordinates.y - 1));

            if (coordinates.x < matrix.GetLength(0) - 1)
                neighbors.Add((coordinates.x + 1, coordinates.y));

            if (coordinates.y < matrix.GetLength(1) - 1)
                neighbors.Add((coordinates.x, coordinates.y + 1));

            return neighbors;
        }
        //one
        static int[,] Read(string[] input)
        {
            var matrix = new int[input.Length, input[0].Length];
            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 0; j < input.Length; j++)
                {

                    matrix[i, j] = int.Parse(input[i][j].ToString());

                }
            }
            return matrix;
        }

       // wrap for two
       static int[,] Wrap(string[] input)
        {
            var matrix = new int[input.Length * 5, input[0].Length * 5];
            for (int z = 0; z <= 4 * input.Length; z += input[0].Length)
            {
                for (int l = 0; l <= 4 * input.Length; l += input[0].Length)
                {
                    for (int i = 0; i < input.Length; i++)
                    {
                        for (int j = 0; j < input.Length; j++)
                        {

                            var num = int.Parse(input[i][j].ToString()) + l / input.Length + z / input.Length;
                            if (num > 9)
                                num %= 9;
                            matrix[i + l, j + z] = num;
                            matrix[i + l, j + z] = num;

                        }
                    }
                }
            }
            return matrix;
        }
    }
}
