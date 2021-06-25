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
            // My name
            Console.WriteLine("My name is Ivan Isakov.");
            // Get the current date and time
            DateTime datetime = DateTime.Now;
            // Output the current date and time
            Console.WriteLine("The current date and time is {0}.", datetime.ToString());
            // Keep the window open without debugging
            Console.ReadLine();
        }
    }
}
