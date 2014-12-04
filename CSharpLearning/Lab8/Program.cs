using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8
{
    /// <summary>
    /// Lab8 - String Processing
    /// </summary>
    class Program
    {
        /// <summary>
        /// String Processing
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            // EXTRACTING THE PYRAMID SLOT NUMBER
            Console.WriteLine("Enter a string in the following format: ");
            Console.WriteLine("<pyramid slot number>,<block letter>,<whether or not the block should be lit>");
            string pyramidString = Console.ReadLine();
            
            int lenghtToFirstComma = pyramidString.IndexOf(',');    // w ktorym miejscu jest przecinek - int od 0
            string slotNumber = pyramidString.Substring(0,lenghtToFirstComma);
            Console.WriteLine("The slot number is: " + slotNumber);

            // EXTRACTING THE BLOCK LETTER
            // +1 is for ommiting the ',' sign
            pyramidString = pyramidString.Substring(lenghtToFirstComma + 1);
            int lengthToSecondString = pyramidString.IndexOf(',');
            Console.WriteLine("The block letter is: " + pyramidString.Substring(0, lengthToSecondString));

            // EXTRACTING WHETHER OR NOT THE BLOCK SHOULD BE LIT
            pyramidString = pyramidString.Substring(lengthToSecondString + 1);
            Console.WriteLine("The rest is: " + pyramidString);
        }
    }
}
