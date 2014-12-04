using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7
{
    /// <summary>
    /// Program will read in a user's birthday
    /// </summary>
    class Program
    {
        /// <summary>
        /// Birthday fun
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            // value
            string Month;
            int Day;

            // Prompt for the month of the user's birthday
            Console.WriteLine("Enter your birth month: ");
            Month = Console.ReadLine();

            // Prompt for the day of the user's birthday
            Console.WriteLine("Enter your birth day (1-31): ");
            Day = int.Parse(Console.ReadLine());
            
            Console.WriteLine();

            // Print the values stored to the user with appropriate message
            Console.WriteLine("Your birthday is " + Month + " " + Day);

            Console.WriteLine();

            // REMINDERS
            //// Prompt for the month of the user's birthday
            //Console.WriteLine("Enter your birth month: ");
            //Month = Console.ReadLine();

            //// Prompt for the day of the user's birthday
            //Console.WriteLine("Enter your birth day (1-31): ");
            //Day = int.Parse(Console.ReadLine());
            //Console.WriteLine();

            if (Day == 1)
            {
                if (Month == "January")
                {
                    Day = 31;
                    Month = "December";
                }
                else if (Month == "February")
                {
                    Day = 31;
                    Month = "January";
                }
                else if (Month == "March")
                {
                    Day = 28;
                    Month = "February";
                }
                else if (Month == "April")
                {
                    Day = 31;
                    Month = "March";
                }
                else if (Month == "May")
                {
                    Day = 30;
                    Month = "April";
                }
                else if (Month == "June")
                {
                    Day = 31;
                    Month = "May";
                }
                else if (Month == "July")
                {
                    Day = 30;
                    Month = "June";
                }
                else if (Month == "August")
                {
                    Day = 31;
                    Month = "July";
                }
                else if (Month == "September")
                {
                    Day = 31;
                    Month = "August";
                }
                else if (Month == "October")
                {
                    Day = 30;
                    Month = "September";
                }
                else if (Month == "November")
                {
                    Day = 31;
                    Month = "October";
                }
                else if (Month == "December")
                {
                    Day = 30;
                    Month = "November";
                }
            }

            // Print the values stored to the user with appropriate message
            Console.WriteLine("You'll receive an email reminder on " + Month + " " + Day);

        }
    }
}
