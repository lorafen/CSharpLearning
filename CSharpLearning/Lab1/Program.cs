using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = "Anna";
            Console.WriteLine("My name is " + name);
            
            Console.Write("Enter a new name: ");
            name = Console.ReadLine();
            Console.WriteLine("My name is " + name);
            
            Console.Clear();

            Console.WriteLine("My three favourite games are: ");
            Console.WriteLine("- Witcher");
            Console.WriteLine("- Diablo");
            Console.WriteLine("- Dead Island");
            

        }
    }
}
