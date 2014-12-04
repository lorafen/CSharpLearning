using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IfStatements
{
    /// <summary>
    /// Demonstrates if statements
    /// </summary>
    class Program
    {
        /// <summary>
        /// Demonstrates various forms of if statement
        /// </summary>
        /// <param name="args">command-line args</param>
        static void Main(string[] args)
        {
            // ask for and get user answer
            Console.Write("Pick up the shiny thing? (y, n): ");
            char answer = Console.ReadLine()[0];

            // print appropriate message
            if ( (answer == 'y') || (answer == 'Y') )
            {
                Console.WriteLine("You have the shiny object");
            }
            else if ((answer == 'n') || (answer == 'N'))
            {
                Console.WriteLine("You don't have the shiny object");
            }
            else
            {
                Console.WriteLine("You are a n00b");
            }

            Console.WriteLine();
        }
    }
}
