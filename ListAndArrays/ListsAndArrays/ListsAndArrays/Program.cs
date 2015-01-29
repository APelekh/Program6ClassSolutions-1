using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListsAndArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            // fixed length array
            string[] foodArray = new string[5];
            foodArray[0] = "quinoa"; // set at index
            foodArray[1] = "grapes";
            Console.WriteLine(foodArray[0]); // print value at index

            // make the array to a list
            List<string> foodList = foodArray.ToList();

            // accessing two dimensional arrays
            int[,] twoD = new int[5,5]; // declare
            twoD[1, 4] = 7; // set value at coordinate
            Console.WriteLine(twoD[1,4]); // get value at coordinate

            // LISTS
            List<string> teams = new List<string>(); // declare
            teams.Add("broncos"); // adds to the end of the list
            teams.Add("tigers");
            teams.Add("eagles");
            Console.WriteLine("before sort"); 
            // print each value in the list
            for (int i = 0; i < teams.Count; i++)
            {
                Console.WriteLine(teams[i]);
            }

            teams.Sort(); // sort the list (alphabetically)

            Console.WriteLine("after sort");
            // print each value in the list
            for (int i = 0; i < teams.Count; i++)
            {
                Console.WriteLine(teams[i]);
            }

            // Insert at an object certain index
            teams.Insert(0, "49ers");

            Console.WriteLine("after insert at index 0");
            // check how the insert went
            Console.WriteLine(teams[0]); 
            Console.WriteLine(teams[1]);

            Console.WriteLine("resorted");
            //resort after adding a digit
            teams.Sort();
            // print to list to console
            for (int i = 0; i < teams.Count; i++)
            {
                Console.WriteLine(teams[i]);
            }

            // using Contains
            if (teams.Contains("Broncos"))
            {
                // only written if the string is exactly
                // contained in the list
                Console.WriteLine("has broncos");
            }

            // Reading the index where a value is located
            Console.WriteLine("Tigers is located at index " +teams.IndexOf("tigers"));

            // ways delete from list
            teams.Remove("eagles");
            teams.RemoveAt(0);

            // keep the console open
            Console.ReadKey();
        }
    }
}
