using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingAssignment5
{
    class Program
    {
        /// <summary>
        /// WAR GAME
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            // Declare a variable for a random number generator and create a new object for that wariable
            Random rand = new Random();

            // Declare other variables as necessary to keep track of each player's roll, 
            // each player's number of wins, and whether or not we should play another game of War 
            int playerOneWin = 0;
            int playerTwoWin = 0;

            const int MAX_BATTLES = 21;
            const int MAX_SIDED_DIE = 13;

            int diePlayerOne = 0;
            int diePlayerTwo = 0;

            string theWinnerIs = " ";
            string battleOrWar = "BATTLE:";

            char YesOrNo = 'y';

            // Print a "welcome" message to the user telling them that the program will play games of War
            Console.WriteLine("Welcome to War!");
            Console.WriteLine();

            while ((YesOrNo == 'y') || (YesOrNo == 'Y'))
            {
                playerOneWin = 0;
                playerTwoWin = 0;
                
                for (int i = 0; i < MAX_BATTLES; i++)
                {
                    diePlayerOne = rand.Next(1, MAX_SIDED_DIE);
                    diePlayerTwo = rand.Next(1, MAX_SIDED_DIE);

                    if (diePlayerOne > diePlayerTwo)
                    {
                        playerOneWin += 1;
                        battleOrWar = "BATTLE:";
                        theWinnerIs = "P1 Wins!";
                    }
                    else if (diePlayerTwo > diePlayerOne)
                    {
                        playerTwoWin += 1;
                        battleOrWar = "BATTLE:";
                        theWinnerIs = "P2 Wins!";
                    }
                    else if (diePlayerOne == diePlayerTwo)
                    {
                        battleOrWar = "   WAR!";
                        theWinnerIs = " ";
                        i -= 1;
                    }

                    Console.WriteLine(battleOrWar + "  " + " \tP1: " + diePlayerOne + " \tP2: " + diePlayerTwo + "\t" + theWinnerIs);
                }

                if (playerOneWin > playerTwoWin)
                {
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("P1 is the overall Winner with " + playerOneWin + " battles!");
                    Console.WriteLine();
                    Console.WriteLine();
                }
                else if (playerTwoWin > playerOneWin)
                {
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("P2 is the overall Winner with " + playerTwoWin + " battles!");
                    Console.WriteLine();
                    Console.WriteLine();
                }
                
                Console.WriteLine();
                Console.WriteLine();

                Console.Write("Do you want to play again (y/n)? ");
                YesOrNo = char.Parse(Console.ReadLine());

                Console.WriteLine();
                Console.WriteLine();
            }
        }
    }
}
