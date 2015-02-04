using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTricks
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("whoa, i'm a cool color");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("back to white");

            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("pretty hard to read, huh?");

            Console.Clear(); // clears the screen

            //write at specific locations
            Console.SetCursorPosition(5, 15);
            Console.Write("something");

            Console.SetCursorPosition(12, 7);
            Console.Write("something");

            string input = Console.ReadLine(); 
           
            //validating user input
            int test = int.Parse(input);

            int intInput = 0;
            while(!int.TryParse(input, out intInput))
            {
                //get more input
                Console.WriteLine("invalid, please try again");
            }


            Console.ReadKey();
        }
    }
}
