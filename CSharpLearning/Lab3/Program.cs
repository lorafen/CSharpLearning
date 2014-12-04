using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    /// <summary>
    /// Program to convert a temperature from Fahrenheit to Celsius and back again
    /// </summary>
    class Program
    {
        /// <summary>
        /// Program to convert a temperature from Fahrenheit to Celsius and back again
        /// </summary>
        /// <param name="args"></param>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            float originalTemperatureF;
            float calculatedTemperatureC;
            float calculatedTemperatureF;

            Console.Write("Enter temperature [Fahrenheit]: ");
            originalTemperatureF = float.Parse(Console.ReadLine());
            
            // Convert from Fahrenheit to Celsius
            calculatedTemperatureC = ((originalTemperatureF - 32) / 9) * 5;

            // Convert from Celsius to Fahrenheit
            calculatedTemperatureF = ((calculatedTemperatureC * 9) / 5 + 32);

            // Display message
            Console.WriteLine(originalTemperatureF + " degrees Fahrenheit is " + calculatedTemperatureC + " degrees Celsius");
            Console.WriteLine(calculatedTemperatureC + " degrees Celsius is " + calculatedTemperatureF + " degrees Fahrenheit");
            Console.WriteLine();

        }
    }
}
