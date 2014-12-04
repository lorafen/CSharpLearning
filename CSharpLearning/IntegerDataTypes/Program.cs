using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegerDataTypes
{
    /// <summary>
    /// Demonstrates Integer Data Types 
    /// </summary>
    class Program
    {
        /// <summary>
        /// Demonstrates integer data type
        /// </summary>
        /// <param name="args">command-line args</param>
        static void Main(string[] args)
        {
            // declare integer variable and constat 
            int totalSecondsPlay = 100;
            const int SECONDS_PER_MINUTE = 60;

            // calculate minutes and seconds
            int minutes = totalSecondsPlay / SECONDS_PER_MINUTE;
            int seconds = totalSecondsPlay % SECONDS_PER_MINUTE;
            int testValue = 2147483647;


            // print results
            Console.WriteLine("Minutes: " + minutes);
            Console.WriteLine("Seconds: " + seconds);
            Console.WriteLine(testValue + 1);
        }
    }
}
