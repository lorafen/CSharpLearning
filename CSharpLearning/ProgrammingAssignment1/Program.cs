using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingAssignment1
{
    /// <summary>
    /// Programming Assignment 1
    /// </summary>
    class Program
    {
        /// <summary>
        /// Assignment 1
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome!");
            Console.WriteLine("This application will calculate your average gold-collecting perfomance.");
            // Total score input
            Console.WriteLine("Total gold: ");
            int gold = Convert.ToInt32(Console.ReadLine()); //int.Parse(Console.ReadLine());
            // Total time
            Console.WriteLine("Total of hours you've played the game: ");
            float hours = float.Parse(Console.ReadLine());
            // Counting minutes
            float minutes = hours * 60;
            // Calculate the gold per minute
            float goldPerMinute = gold / minutes;
            // Printing out all of data
            Console.WriteLine("Gold: " + gold);
            Console.WriteLine("Hours played: " + hours);
            Console.WriteLine("Gold per minute: " + goldPerMinute);
        }
    }
}
