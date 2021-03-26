using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SodukoGame;

namespace Suduko
{
    class Program
    {
        static void Main(string[] args)
        {
            SodukoGame.SodukoGame s = new SodukoGame.SodukoGame();


            int[] subG = s.GetSubGrid(5);
            s.PrintSubGrid(5);
            Console.WriteLine("\n\n");
            Console.WriteLine("This Grid :\t"+s.IsValid(subG));
            Console.WriteLine();
            Console.WriteLine("Entire Grids:\t"+s.IsGameWon());
            Console.ReadKey();
        }

        
    }
}
