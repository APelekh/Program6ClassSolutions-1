using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week1Review
{
    class Program
    {
        static void Main(string[] args)
        {
            SpaceRemover("a cat is a great pet");

            //a built in space remover
            string noSpaces = "lots of spaces".Replace(" ", string.Empty);
            
            //using a inline-string to do a check if a letter is a vowel
            //if ("aeiou".Contains(noSpaces[1].ToString().ToLower()))
            //{

            //}
            Console.WriteLine(NumberRounder(12));
            Console.WriteLine(NumberRounder(16));
            Console.WriteLine(NumberRounder(19));
            Console.WriteLine(NumberRounder(19112341));


            Console.WriteLine(AnNoYiNgTeXtIfYeR("this is annoying and hard to read.  i am so 90s.  aol teen chat 13. a/s/l?"));
            //keep console open
            Console.ReadKey();
        }

        /// <summary>
        /// Takes in a string, removes all the spaces
        /// </summary>
        /// <param name="inputString">string to despacify</param>
        /// <returns>a string with no faces</returns>
        static string SpaceRemover(string inputString)
        {
            //declare a empty return string
            string returnString = string.Empty;

            //loop over each letter
            for (int i = 0; i < inputString.Length; i++)
            {
                //get an individual letter
                string letter = inputString[i].ToString();
                if (letter != " ")
                {
                    //huzzah!  letter is not a space
                    returnString = returnString + letter;
                }
            }
            //loop completes, return our return string
            return returnString;

        }

        /*  i'm a comment
         * and i go many
         * lines 
         * deep
         * stuff */


        static void DeclaringVariables()
        {
            //declaring a variable
            int count = 10;
            while (count < 20)
            {
                count++;
            }
            
            //int count = 0   -- wrong, doesnt work
            count = 0;
            while (count < 10) { count++; }
        }

        /// <summary>
        /// Counts the number of instances of a specific letter in a string
        /// </summary>
        /// <param name="letterToCount">letter to count</param>
        /// <param name="stringToSearch">string to search</param>
        static void SpecificLetterCounter(string letterToCount, string stringToSearch)
        {
           
            int numberOfHits = 0;  //holds the number of matches found
            
            //loop through each letter
            for (int i = 0; i < stringToSearch.Length; ++i)
            {
                //get a letter
                string letter = stringToSearch[i].ToString();

                //comparing the current letter with the letter we are trying to find.  making sure both are in lowercase.
                if (letter.ToLower() == letterToCount.ToLower())
                {
                    //found one, add one to the counter
                    numberOfHits++;
                }
            }
            //Output: 
            // <stringToSearch> has X letterToCount's in it
            // Sally is sunny has 3 s's in it
            Console.WriteLine("{0} has {1} {2}'s in it.", stringToSearch, numberOfHits, letterToCount);

       
        }

        // input: 7  output: 5
        // input: 2  output: 0
        // input: 9  output: 10
        // input: 13 output: 15
        // input: 19 output: 20
        /// <summary>
        /// NumberRounder, rounds an integer to the nearest 5
        /// </summary>
        /// <param name="numberToRound">number to round off</param>
        /// <returns>nearest 5</returns>
        static int NumberRounder(int numberToRound)
        {
            // number to string
            // string numberString = numberToRound.ToString();
            // int intString = int.Parse(numberString);
            
            int remainder  = numberToRound % 5;
            if (remainder > 2)
            {
                //ex. 18
                // 18 - 3 = 15 + 5 = 20
                return (numberToRound - remainder + 5);
            }
            else
            {
                return (numberToRound - remainder);
            }

            // Juli's way
            //if (remainder == 1)
            //{
            //    return numberToRound - 1;
            //}
            //else if (remainder == 2)
            //{
            //    return numberToRound - 2;
            //}
            // etc etc etc..

 
        }

        /// <summary>
        /// Take in a string, it will return a string with letters alternation between upper and lower case.
        /// </summary>
        /// <param name="notAnnoyingString">string to make annoying</param>
        /// <returns>hard to read string</returns>
        static string AnNoYiNgTeXtIfYeR(string notAnnoyingString)
        {
            //input:  "nickleback"
            //output: "NiCkLeBaCk"
            // declare a return string for output
            string returnString = string.Empty;

            //looping over every letter
            for (int i = 0; i < notAnnoyingString.Length; i++)
            {
                //get a letter to examine
                string currentLetter = notAnnoyingString[i].ToString();
                //see if the position of the letter is odd or even
                if (i % 2 == 0)
                {
                    //even, make it CAPITAL
                    returnString += currentLetter.ToUpper();
                }
                else
                {
                    //odd, make that sucka small
                    returnString += currentLetter.ToLower();
                }

            }
            //loop finished, return the return string
            return returnString;
        }
   }
}
