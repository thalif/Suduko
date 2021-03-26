using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodukoGame
{
    public class SodukoGame
    {
        int A = 0, B = 1, C = 2;
        static int[,] Board = new int[9, 9]
                {
                    {1, 2, 3, 4, 5, 6, 7, 8, 9},
                    {7, 8, 9, 1, 2, 3, 4, 5, 6},
                    {4, 5, 6, 7, 8, 9, 1, 2, 3},
                    {3, 1, 2, 8, 4, 5, 9, 6, 7},
                    {6, 9, 7, 3, 8, 2, 8, 4, 5},
                    {8, 4, 5, 6, 9, 7, 3, 1, 2},
                    {2, 3, 1, 5, 7, 4, 6, 9, 8},
                    {9, 6, 8, 2, 3, 1, 5, 7, 4},
                    {5, 7, 4, 9, 6, 8, 2, 3, 1},
                };

        static Dictionary<string, int> SubGrid = new Dictionary<string, int>();
        
        public int GetGridOf(int x, int y)
        {
            string X = GetPossibleIndex(x).ToString();
            string Y = GetPossibleIndex(y).ToString();
            return SubGrid[X+"-"+Y];
        }
        public void PrintBoard()
        {
            int count = 0;
            for (int j = 0; j < 9; j++)
            {
                for (int i = 0; i < 9; i += 3)
                {
                    Console.Write(Board[A + j, A + i] + "\t" + Board[A + j, B + i] + "\t" + Board[A + j, C + i] + "\t");
                }
                count++;
                if (count == 3)
                {
                    Console.WriteLine("\n\n\n");
                    count = 0;
                }
                else
                    Console.WriteLine();
            }
        }

        public int GetFirstElement(int x, int y)
        {
            int X = GetPossibleIndex(x);
            int Y = GetPossibleIndex(y);
            return Board[X, Y];
        }
        public int GetPossibleIndex(int index)
        {
            while (index % 3 != 0)
                index--;
            return index;
        }
        
        public void PrintSubGrid(int _grid)
        {
            int[]  _thatSubGrid = GetSubGrid(_grid);
            for(int i = 0; i < _thatSubGrid.Length; i++)
            {
                if(i%3 == 0)
                    Console.WriteLine("\n");
                Console.Write(_thatSubGrid[i]+"\t");
            }
        }
        public int[] GetSubGrid(int _grid)
        {
            string Str = SubGrid.FirstOrDefault(o => o.Value == _grid).Key;
            int[] XansY = Str.Split('-').Select(int.Parse).ToArray();
            int X = XansY[0];
            int Y = XansY[1];

            int[] _SubGrid = new int[9];
            int p = 0;
            for(int i = X; i < 3 + X; i++)
            {
                _SubGrid[p+A] = Board[i, Y + A];
                _SubGrid[p+B] = Board[i, Y + B];
                _SubGrid[p+C] = Board[i, Y + C];
                p += 3;
            }
            return _SubGrid;
        }
        public bool IsValid(int _subGridOf)
        {
            int[] _givenSubGrid = GetSubGrid(_subGridOf);
            int[] SudukoGrid = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            foreach (int item in SudukoGrid)
            {
                if (!_givenSubGrid.Contains(item))
                    return false;
            }
            return true;
        }
        public bool IsValid(int[] _subArray)
        {
            int[] SudukoGrid = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            foreach (int item in SudukoGrid)
            {
                if (!_subArray.Contains(item))
                    return false;
            }
            return true;
        }

        public bool IsGameWon()
        {
            for(int i = 0; i < 9; i++)
            {
                if (!IsValid(GetSubGrid(i + 1)))
                    return false;
            }
            return true;
        }
        public SodukoGame()
        {
            SubGrid.Add("0-0", 1);
            SubGrid.Add("0-3", 2);
            SubGrid.Add("0-6", 3);
            SubGrid.Add("3-0", 4);
            SubGrid.Add("3-3", 5);
            SubGrid.Add("3-6", 6);
            SubGrid.Add("6-0", 7);
            SubGrid.Add("6-3", 8);
            SubGrid.Add("6-6", 9);
        }
    }
}
