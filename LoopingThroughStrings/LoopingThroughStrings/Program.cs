using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoopingThroughStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            //function call for the vowel counter
            string testString = "the lazy dog jumps over the also lazy bear";
            Console.WriteLine("We found {0} vowels in {1}", VowelCounter3000(testString), testString);

            Console.WriteLine("The average length of a word in \"{0}\" is {1:F4}", testString, AverageWordLengthFinder8000(testString));

            //another way to calculate the average using lambdas.
            //Console.WriteLine(testString.Split(' ').Average(x => x.Length));
            //another way to count the number of vowels using lambdas.
            //testString.Count(x => "aeiou".Contains(x.ToString().ToLower()));

            //OldTimeyTextPrinter Function Calls
            OldTimeyTextPrinter(testString, 100);
            OldTimeyTextPrinter(testString, 40);
            OldTimeyTextPrinter(testString, 5);

            //keep the console window open with...
            Console.ReadKey();
        }

        //new functions are declared outside of other functions, but inside of a class

        /// <summary>
        /// Count the number of vowels in a string
        /// </summary>
        /// <param name="inputText">the string to analyze</param>
        /// <returns>the number of vowels found</returns>
        static int VowelCounter3000(string inputText)
        {
            //this is our counter for vowels
            int numberOfVowelsFound = 0;
            
            //we need loop through all indexes to compare each letter

            // "hello" is 5 chars long, but the last index is 4
            for (int i = 0; i < inputText.Length; i = i + 1)
            {
                //pulling out an individual letter, converting to the lowercase version
                char letter = char.ToLower(inputText[i]);
                //is it a vowel?
                if (letter == 'a' || letter == 'e' || letter == 'i' || letter == 'o' || letter == 'u')
                {
                    //yes, it is a vowel! count it!
                    numberOfVowelsFound = numberOfVowelsFound + 1;
                }
            }
            //loop complete.  gone through every letter of the string, counted all the vowels.  return the number of vowels found
            return numberOfVowelsFound;
        }

        /// <summary>
        /// Finds the average length of a word in a string
        /// </summary>
        /// <param name="inputText">string to analyze</param>
        /// <returns>average length of characters in a word</returns>
        static double AverageWordLengthFinder8000(string inputText)
        {
            //counters to hold our values to calculate an average
            // need to use doubles, because division on integers results in rounding
            double totalNumberOfCharacters = 0;
            double totalNumberOfWords = 0;

            //we need to split a string into words
            //   "hello how are you" >>> "hello|how|are|you"
            string[] wordArray = inputText.Split(' ');

            //loop over each word in the our wordArray
            for (int i = 0; i < wordArray.Length; i++)
            {
                //get the current word
                string currentWord = wordArray[i];
                //lets process the word
                totalNumberOfWords++;
                
                //these two lines below are identical
                //totalNumberOfCharacters = totalNumberOfCharacters + currentWord.Length;
                totalNumberOfCharacters += currentWord.Length;
            }

            //return our results
            // average = total/number of items
            return totalNumberOfCharacters / totalNumberOfWords;

        }

        /// <summary>
        /// Prints text to the screen like an 80s Apple IIe
        /// </summary>
        /// <param name="inputText">text to print</param>
        /// <param name="pauseDuration">pause between characters in milliseconds</param>
        static void OldTimeyTextPrinter(string inputText, int pauseDuration)
        {
            //loop over each character
            for (int i = 0; i < inputText.Length; i++)
            {
                //get a letter
                char letter = inputText[i];
                //print the letter to the screen
                Console.Write(letter);
                //pause for a hot second.
                System.Threading.Thread.Sleep(pauseDuration);
            }
            //after the text is complete, write a line break
            Console.WriteLine();
        }

    }
}
