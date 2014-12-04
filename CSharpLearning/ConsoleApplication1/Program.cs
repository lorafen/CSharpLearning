using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroToStrings
{
    /// <summary>
    /// Demonstrates string basics
    /// </summary>
    class Program
    {
        ////--------------------------------------------------------------//
        ///// <summary>
        ///// Demonstrates string basics
        ///// </summary>
        ///// <param name="args">command-line args</param>
        //static void Main(string[] args)
        //{
        //    // prompt for and read in gamertag
        //    Console.Write("Enter gamertag: ");
        //    string gamertag = Console.ReadLine();
        //    // prompt for and read in level
        //    Console.Write("Enter level: ");
        //    int level = int.Parse(Console.ReadLine());

        //    // extract the first character of the gamertag
        //    char firstGamerTagChar = gamertag[0];

        //    // print out values
        //    Console.WriteLine();
        //    Console.WriteLine("Gamertag: " + gamertag);
        //    Console.WriteLine("Level: " + level);
        //    Console.WriteLine("First char: " + firstGamerTagChar);
        //    Console.WriteLine();
        //    //--------------------------------------------------------------//

        /// <summary>
        /// Demonstrates useful string operations
        /// </summary>
        /// <param name="args">command-line args</param>
        static void Main(string[] args)
        {
            // read in csv string
            Console.Write("Enter name and percent (name,percent): ");
            string csvString = Console.ReadLine();
            
            // find coma location
            int commaLocation = csvString.IndexOf(',');

            // ectract name and percent
            string name = csvString.Substring(0, commaLocation);
            float percent = float.Parse(csvString.Substring(commaLocation + 1));

            // print name and percent
            Console.WriteLine("Name: " + name);
            Console.WriteLine("Percent: " + percent);
            Console.WriteLine();


        }
    }
}
