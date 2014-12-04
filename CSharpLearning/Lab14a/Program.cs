using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab14a
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the lower bound for number: ");
            int lowerBound = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the upper bound for number: ");
            int upperBound = int.Parse(Console.ReadLine());

            for (int i = lowerBound; i < upperBound + 1; i++)
            {
                Console.WriteLine(i);
            }

        }
    }
}
