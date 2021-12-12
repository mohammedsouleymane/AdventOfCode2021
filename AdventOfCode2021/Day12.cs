using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021
{
    internal class Day12
    {
        private static string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent + "/Input/Day12/Input.txt";

        public static void OneAndTwo()
        {
            var input = File.ReadAllLines(path);

            var dic = new Dictionary<string, List<string>>();
            var paths = new Dictionary<string, int>();
            foreach (var group in input.GroupBy(x => x.Split("-")[0]))
            {
                List<string> list = new();
                foreach (var item in group)
                {
                    list.Add(item.Split("-")[1]);
                }
                dic.Add(group.Key, list);
            }

            foreach (var group in input.GroupBy(x => x.Split("-")[1]))
            {
                List<string> list = new();
                foreach (var item in group)
                {
                    list.Add(item.Split("-")[0]);
                }
                if (dic.ContainsKey(group.Key))
                    dic[group.Key] = dic[group.Key].Concat(list).ToList();
                else
                    dic.Add(group.Key, list);

                if (dic[group.Key].Contains("start"))
                    dic[group.Key].Remove("start");
            }

            foreach (var item in dic["start"])
            {
                Paths1(item, dic, new Stack<string>());
            }
            Console.WriteLine(queue.Count());
            queue = new Queue<Stack<string>>();
            foreach (var item in dic["start"])
            {
                Paths2(item, dic, new Stack<string>());
            }

            Console.WriteLine(queue.Count());
        }

        static Queue<Stack<string>> queue = new Queue<Stack<string>>();
        private static void Paths1(string cave, Dictionary<string, List<string>> dic, Stack<string> path)
        {
            path.Push(cave);
            if (dic[cave].Contains("end"))
            {
                path.Push("end");
                queue.Enqueue(new Stack<string>(path));
                path.Pop();
            }

            foreach (var item in dic[cave])
            {
                if (item != "end" && (!path.Contains(item) || char.IsUpper(item[0])))
                    Paths1(item, dic, new Stack<string>(path));
            }
        }

        private static void Paths2(string cave, Dictionary<string, List<string>> dic, Stack<string> path)
        {
            path.Push(cave);
            var num = 0;
            try { num = path.Where(x => char.IsLower(x[0])).GroupBy(x => x).Max(x => x.Count()); }
            catch { num = 0; }
            if (dic[cave].Contains("end"))
            {
                path.Push("end");
                queue.Enqueue(new Stack<string>(path));
                path.Pop();
            }

            foreach (var item in dic[cave])
            {
                if (item != "end" && (num != 2 || !path.Contains(item) || char.IsUpper(item[0])))
                    Paths2(item, dic, new Stack<string>(path));
            }

        }
    }
}

