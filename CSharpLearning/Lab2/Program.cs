using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            int age = 28;

            Console.WriteLine("My age is " + age);
            Console.WriteLine();

            const int MAX_SCORE = 100;

            Random randomValue = new Random();
            int score = randomValue.Next(0, 100);

            float percent = ((float)score / MAX_SCORE) * 100;

            Console.WriteLine("Percent value: " + percent);
            Console.WriteLine();

        }
    }
}
