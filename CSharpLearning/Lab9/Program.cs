using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9
{
    /// <summary>
    /// IF AND SWITCH STATEMENTS
    /// </summary>
    class Program
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            // Variable
            int answer;

            // Create a menu using an if statement
            Console.WriteLine("************");
            Console.WriteLine("Menu:");
            Console.WriteLine();
            Console.WriteLine("1 - New Game");
            Console.WriteLine("2 - Load Game");
            Console.WriteLine("3 - Options");
            Console.WriteLine("4 - Quit");
            Console.WriteLine("************");

            answer = int.Parse(Console.ReadLine());

            if (answer == 1)
            {
                Console.WriteLine("New game");
            }
            else if (answer == 2)
            {
                Console.WriteLine("Loading game ....");
            }
            else if (answer == 3)
            {
                Console.WriteLine("************");
                Console.WriteLine("Menu:");
                Console.WriteLine();
                Console.WriteLine("1 - New Game");
                Console.WriteLine("2 - Load Game");
                Console.WriteLine("3 - Options");
                Console.WriteLine("4 - Quit");
                Console.WriteLine("************");
                answer = int.Parse(Console.ReadLine());
            }
            else if (answer == 4)
            {
                Console.WriteLine("Quit!");
            }


            Console.WriteLine("************");
            Console.WriteLine("Menu:");
            Console.WriteLine();
            Console.WriteLine("1 - New Game");
            Console.WriteLine("2 - Load Game");
            Console.WriteLine("3 - Options");
            Console.WriteLine("4 - Quit");
            Console.WriteLine("************");
            answer = int.Parse(Console.ReadLine());

            switch (answer)
            {
                case 1:
                    Console.WriteLine("New game!");
                    break;        
                case 2:
                    Console.WriteLine("Loading game ...");
                    break;
                case 3:
                    Console.WriteLine("************");
                    Console.WriteLine("Menu:");
                    Console.WriteLine();
                    Console.WriteLine("1 - New Game");
                    Console.WriteLine("2 - Load Game");
                    Console.WriteLine("3 - Options");
                    Console.WriteLine("4 - Quit");
                    Console.WriteLine("************");
                    answer = int.Parse(Console.ReadLine());
                    break;
                case 4:
                    break;
                default:
                    Console.WriteLine("You chose a wrong options! Try again!");
                    Console.WriteLine("************");
                    Console.WriteLine("Menu:");
                    Console.WriteLine();
                    Console.WriteLine("1 - New Game");
                    Console.WriteLine("2 - Load Game");
                    Console.WriteLine("3 - Options");
                    Console.WriteLine("4 - Quit");
                    Console.WriteLine("************");
                    answer = int.Parse(Console.ReadLine());
                    break;
            }


        }
    }
}
