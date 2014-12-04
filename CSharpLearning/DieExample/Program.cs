using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DieExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // test standrad Die
            Die standardDie = new Die();
            Console.WriteLine("Num of sides: " + standardDie.NumSides);
            Console.WriteLine("Top side: " + standardDie.TopSide);
            Console.WriteLine();

            // roll and print results
            Console.WriteLine("Rolling ...");
            standardDie.Roll();
            Console.WriteLine();
            Console.WriteLine("Top side: " + standardDie.TopSide);
            Console.WriteLine();

            Die d20die = new Die(20);
            Console.WriteLine("Num of sides: " + d20die.NumSides);
            Console.WriteLine("Top side: " + d20die.TopSide);
            d20die.Roll();
            Console.WriteLine("Top side: " + d20die.TopSide);

        }
    }
}
