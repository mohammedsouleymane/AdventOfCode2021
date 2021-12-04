namespace AdventOfCode2021
{
    internal class Day4
    {
        private static string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent + "/Input/Day4/Input.txt";
        public static void One()
        {
            var input = File.ReadAllLines(path).ToList();

            List<int[,]> boards = new();
            int[] cardsTodraw = input[0].Split(",").Select(x => int.Parse(x)).ToArray();
            input.Remove(input[0]);
            List<int> drawnCards = cardsTodraw.Where(x => Array.IndexOf(cardsTodraw, x) < 5).ToList();

            string boardsAsString = "";
            foreach (var item in input)
            {
                if (item != "")
                {
                    boardsAsString += item + " ";
                }
                else if (boardsAsString != "")
                {
                    boardsAsString += "\n";
                }
            }

            List<int[]> boardsIn1DArr = new();
            foreach (var item in boardsAsString.Split("\n"))
            {
                boardsIn1DArr.Add(item.Split(" ").Where(x => x != "").Select(x => int.Parse(x)).ToArray());
            }

            foreach (var item in boardsIn1DArr)
            {
                int[,] arr2D = new int[5, 5];
                int l = 0;
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        arr2D[i, j] = item[l];
                        l++;
                    }
                }
                boards.Add(arr2D);
            }

            int rows = 0;
            int cols = 0;
            Dictionary<int[,], int> possibleWinners = new();
            for (int m = 0; m < drawnCards.Count; m++)
            {
                foreach (var board in boards)
                {

                    for (int i = 0; i < 5; i++)
                    {
                        rows = 0;
                        cols = 0;
                        for (int j = 0; j < 5; j++)
                        {
                            if (drawnCards.Contains(board[i, j]))
                                rows++;
                            if (drawnCards.Contains(board[j, i]))
                                cols++;
                            if (cols == 5 || rows == 5)
                            {
                                if (possibleWinners.ContainsKey(board))
                                    possibleWinners[board]++;
                                else
                                    possibleWinners.Add(board, 1);
                            }

                        }
                    }
                }

                if (possibleWinners.Count > 0)
                    break;
                drawnCards.Add(cardsTodraw[drawnCards.Count]);
            }
            var ouput = possibleWinners.Select(x => boardsIn1DArr[boards.IndexOf(x.Key)].Where(x => !drawnCards.Contains(x)).Sum() * drawnCards.Last()).Max();
            Console.WriteLine(ouput);
        }

        public static void Two()
        {
            var input = File.ReadAllLines(path).ToList();

            List<int[,]> boards = new();
            int[] cardsTodraw = input[0].Split(",").Select(x => int.Parse(x)).ToArray();
            input.Remove(input[0]);
            List<int> drawnCards = cardsTodraw.Where(x => Array.IndexOf(cardsTodraw, x) < 5).ToList();

            string boardsAsString = "";
            foreach (var item in input)
            {
                if (item != "")
                {
                    boardsAsString += item + " ";
                }
                else if (boardsAsString != "")
                {
                    boardsAsString += "\n";
                }
            }

            List<int[]> boardsIn1DArr = new();
            foreach (var item in boardsAsString.Split("\n"))
            {
                boardsIn1DArr.Add(item.Split(" ").Where(x => x != "").Select(x => int.Parse(x)).ToArray());
            }

            foreach (var item in boardsIn1DArr)
            {
                int[,] arr2D = new int[5, 5];
                int l = 0;
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        arr2D[i, j] = item[l];
                        l++;
                    }
                }
                boards.Add(arr2D);
            }

            int rows = 0;
            int cols = 0;
            Dictionary<int[,], int> possibleWinners = new();
            for (int m = 0; m < drawnCards.Count; m++)
            {
                foreach (var board in boards)
                {

                    for (int i = 0; i < 5; i++)
                    {
                        rows = 0;
                        cols = 0;
                        for (int j = 0; j < 5; j++)
                        {
                            if (drawnCards.Contains(board[i, j]))
                                rows++;
                            if (drawnCards.Contains(board[j, i]))
                                cols++;
                            if (cols == 5 || rows == 5)
                            {
                                if (possibleWinners.ContainsKey(board))
                                    possibleWinners[board]++;
                                else
                                    possibleWinners.Add(board, 1);
                            }

                        }
                    }
                }

                if (possibleWinners.Count == boards.Count)
                    break;
                drawnCards.Add(cardsTodraw[drawnCards.Count]);
            }
          
            var lastWinner = boardsIn1DArr[boards.IndexOf(possibleWinners.Last().Key)].Where(x => !drawnCards.Contains(x)).Sum() ;
            Console.WriteLine(lastWinner *drawnCards.Last());
        }
    }
}

