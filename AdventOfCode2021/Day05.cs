using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021
{

    internal class Day05
    {
        private static string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent + "/Input/Day05/Input.txt";
        public static void One()
        {
            //var input = File.ReadAllLines(path).Where(x => x.Split("->")[0].Trim().Split(",")[0] == x.Split("->")[1].Trim().Split(",")[0] || x.Split("->")[0].Trim().Split(",")[1] == x.Split("->")[1].Trim().Split(",")[1]);
            var input = File.ReadAllLines(path);
            Dictionary<string, int> coordinates = new();

            foreach (var item in input)
            {
                string start = item.Split("->")[0].Trim();
                string end = item.Split("->")[1].Trim();
                int iterations = 0;
                string otherCoordinate = "";
                string coordinate = start;

                if (start.Split(",")[1] == end.Split(",")[1])
                {
                    iterations = Math.Abs(int.Parse(end.Split(",")[0]) - int.Parse(start.Split(",")[0]));
                    if (int.Parse(start.Split(",")[0]) > int.Parse(end.Split(",")[0]))
                        coordinate = end;

                    coordinates[start] = coordinates.ContainsKey(start) ? ++coordinates[start] : 1;

                    for (int i = 1; i < iterations; i++)
                    {
                        string between = int.Parse(coordinate.Split(",")[0]) + i + "," + coordinate.Split(",")[1];
                        coordinates[between] = coordinates.ContainsKey(between) ? ++coordinates[between] : 1;
                    }
                    coordinates[end] = coordinates.ContainsKey(end) ? ++coordinates[end] : 1;
                }
                else if (start.Split(",")[0] == end.Split(",")[0])
                {
                    iterations = Math.Abs(int.Parse(end.Split(",")[1]) - int.Parse(start.Split(",")[1]));
                    if (int.Parse(start.Split(",")[1]) > int.Parse(end.Split(",")[1]))
                        coordinate = end;

                    coordinates[start] = coordinates.ContainsKey(start) ? ++coordinates[start] : 1;
                    for (int i = 1; i < iterations; i++)
                    {
                        string between = int.Parse(coordinate.Split(",")[0]) + "," + (int.Parse(coordinate.Split(",")[1]) + i);
                        coordinates[between] = coordinates.ContainsKey(between) ? ++coordinates[between] : 1;
                    }
                    coordinates[end] = coordinates.ContainsKey(end) ? ++coordinates[end] : 1;
                }
                //part Two

                else if ((start.Split(",")[0] == end.Split(",")[1] && start.Split(",")[1] == end.Split(",")[0]) && (Math.Abs(int.Parse(start.Split(",")[0]) - int.Parse(end.Split(",")[0])) == Math.Abs(int.Parse(start.Split(",")[1]) - int.Parse(end.Split(",")[1]))))
                {

                    iterations = Math.Abs(int.Parse(start.Split(",")[1]) - int.Parse(start.Split(",")[0]));
                    coordinates[start] = coordinates.ContainsKey(start) ? ++coordinates[start] : 1;

                }

                else if (Math.Abs(int.Parse(start.Split(",")[0]) - int.Parse(end.Split(",")[0])) == Math.Abs(int.Parse(start.Split(",")[1]) - int.Parse(end.Split(",")[1])))
                {
                    iterations = Math.Abs(int.Parse(end.Split(",")[1]) - int.Parse(start.Split(",")[1]));
                    otherCoordinate = end;
                    if (int.Parse(start.Split(",")[1]) > int.Parse(end.Split(",")[1]))
                    {
                        coordinate = end;
                        otherCoordinate = start;
                    }
                }

                if (iterations > 0 && otherCoordinate != "")
                {
                    coordinates[start] = coordinates.ContainsKey(start) ? ++coordinates[start] : 1;

                    for (int i = 1; i < iterations; i++)
                    {
                        int minOrPlus = i;
                        int change = -1;
                        if (otherCoordinate != null && int.Parse(otherCoordinate.Split(",")[0]) < int.Parse(coordinate.Split(",")[0]))
                        {
                            minOrPlus = -i;
                            change = 1;
                        }
                        string between = (int.Parse(coordinate.Split(",")[0]) + minOrPlus) + "," + (int.Parse(coordinate.Split(",")[1]) - minOrPlus * change);
                        coordinates[between] = coordinates.ContainsKey(between) ? ++coordinates[between] : 1;
                    }
                    coordinates[end] = coordinates.ContainsKey(end) ? ++coordinates[end] : 1;
                }
            }
            Console.WriteLine(coordinates.Where(x => x.Value >= 2).ToList().Count);
        }
    }
}
