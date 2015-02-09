using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LamdaExpressions
{
    class Program
    {
        public static List<string> icecreamList = new List<string>() { "Chocolate Marshmallow", "Rocky Road", "Coffee", "Chocolate Almond", "Cherry", "Praline Pecan", "Vanilla Fudge Ripple", "Cookies and Cream", "French Vanilla", "French Vanilla", "Neapolitan", "Strawberry", "Butter Pecan", "Chocolate", "Vanilla", "Vanilla"};
        static void Main(string[] args)
        {
            string myString = "lambda";

            // For loop
            for (int i = 0; i < myString.Length; i++)
            {
                // write each letter from the string, one to a line
                Console.WriteLine(myString[i]);
            }

            // For each example
            foreach (char letter in myString)
            {
                // write each letter from the string, one to a line
                Console.WriteLine(letter);
            }
            foreach (string flavor in icecreamList)
            {
                // write each string from the list, one per line
                Console.WriteLine(flavor);
            }

            // Lambda expressions
            
            // orderby length, shortest to longest
            List<string> temp = icecreamList.OrderBy(x => x.Length).ToList();
            // print each string in the list
            foreach (string flavor in temp)
            {
                Console.WriteLine(flavor);
            }

            // shortest item
            Console.WriteLine(icecreamList.OrderBy(x => x.Length).First());

            // longest item
            Console.WriteLine(icecreamList.OrderBy(x=>x.Length).Last());

            // Where()

            // Gets a list of strings which contain chocolate
            List<string> choco = icecreamList.Where(x => x.ToLower().Contains("chocolate")).ToList();
            // Print them
            foreach (string item in choco)
            {
                Console.WriteLine(item);
            }
            // First()
            // shortest
            Console.WriteLine(icecreamList.OrderBy(x => x.Length).First());
            // Last()
            // longest
            Console.WriteLine(icecreamList.OrderBy(x => x.Length).Last());

            // OrderBy()

            // organizes from Longest to shortest length, doesn't print the result
            // doesn't actually modify the list
            icecreamList.OrderByDescending(x => x.Length);

            // Skip()

            // Orders from shortest to longest, skips the first 5, and only those that contain chocolate
            List<string> skipped = icecreamList.OrderBy(x => x.Length).Skip(5).Where(y => y.ToLower().Contains("chocolate")).ToList();
            // prints the resulting
            foreach (string item in skipped)
            {
                Console.WriteLine(item);
            }

            // Take()

            Console.WriteLine("take");
            // only gets the first 2 items in the list
            List<string> take = icecreamList.Take(2).ToList();
            foreach (string item in take)
            {
                Console.WriteLine(item);
            }
            // Count()

            // Gets the number of items that contain vanilla
            int vanillaCount = icecreamList.Count(x => x.ToLower().Contains("vanilla"));
            Console.WriteLine(vanillaCount);

            // Any()

            // True if there are any strings with a string length greater than 10
            bool flavorHere = icecreamList.Any(x => x.Length > 10);
            Console.WriteLine(flavorHere);

            // Distinct()
            Console.WriteLine("before distinct");
            Console.WriteLine(icecreamList.Count());

            Console.WriteLine("after distinct");
            // How many unique items in the list
            Console.WriteLine(icecreamList.Distinct().Count());
            icecreamList = icecreamList.Distinct().ToList();

            // Keep the console open
            Console.ReadKey();
        }
    }
}
