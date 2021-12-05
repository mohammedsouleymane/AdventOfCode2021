
using AdventOfCode2021;

Day1.One();
Day1.Two();
Day2.One();
Day2.Two();
Day3.One();
Day3.Two();
Day4.One();
Day4.Two();
Day5.One();

Dictionary<string, int> coordinates = new();
coordinates.Add("sdfq",7);
coordinates["test"] = !coordinates.ContainsKey("test") ? 1 : 0;