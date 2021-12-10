namespace AdventOfCode2021
{
    class Day01
    {
        private static string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent + "/Input/Day01/Input.txt";
        public static void One()
        {
            List<int> list = File.ReadAllLines(path).Select(x => int.Parse(x)).ToList();
            Console.WriteLine(Enumerable.Range(1, list.Count - 1)
                .Where(i => list[i] > list[i - 1])
                .ToList().Count);
        }

        public static void Two()
        {
            List<int> list = File.ReadAllLines(path).Select(x => int.Parse(x)).ToList();
            Console.WriteLine(Enumerable
                .Range(1, list.Count - 2).
                Where(i => list.Count > i + 1 && list.Count > i + 2 && list[i] + list[i + 1] + list[i + 2] > list[i - 1] + list[i] + list[i + 1])
                .ToList().Count);

            //List<int> result = new();
            //for (int i = 0; i < list.Count - 2; i++)
            //{
            //    if (list.Count > i + 1 && list.Count > i + 2)
            //        result.Add(list[i] + list[i + 1] + list[i + 2]);
            //}
            //Console.WriteLine(Enumerable.Range(1, result.Count - 1).Where(i => result[i] > result[i - 1]).ToList().Count);
        }
    }
}
