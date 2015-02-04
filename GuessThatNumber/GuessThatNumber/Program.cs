using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessThatNumber
{
    public class Program
    {
        //this is the number the user needs to guess.  Set its value in your code using a RNG.
        static int NumberToGuess = 0;
        static Random rng = new Random();
        static bool guessing = true;
        static int numberOfGuesses = 0;

        static void Main(string[] args)
        {
            // get a random number to guess
            NumberToGuess = rng.Next(101);

            // game loop
            while (guessing)
            {
                Console.Clear();
                Console.WriteLine("Guess That Number!!!");
                getUserInput();

            }
            // user has won
            Console.WriteLine("You guessed the number, it took {0} tries",numberOfGuesses);
            Console.ReadKey();
        }
        public static void getUserInput()
        {
            // get user input
            Console.Write("Enter a number between 1 and 100: ");
            string userInput = Console.ReadLine();
            if (ValidateInput(userInput))
            {
                // valid input
                checkTheGuess(userInput);
            }
            else
            {
                // invalid input
                Console.WriteLine("Not a number, invalid input");
                System.Threading.Thread.Sleep(1000);
            }
            numberOfGuesses++;            
        }
        public static void checkTheGuess(string userInput)
        {
            // is it exactly correct
            if(int.Parse(userInput) == NumberToGuess)
            {
                // the user has won
                guessing = false;
            } else if (IsGuessTooHigh(int.Parse(userInput)))
            {
                // too high
                Console.WriteLine("You're guess was too high");
                System.Threading.Thread.Sleep(1000);
            }
            else
            {
                // too low
                Console.WriteLine("You're guess was too low");
                System.Threading.Thread.Sleep(1000);
            }
        }

        public static bool ValidateInput(string userInput)
        {
            //check to make sure that the users input is a valid number between 1 and 100.
            int userInt = 0;
            if (int.TryParse(userInput, out userInt))
            {
                // is an int
                if (userInt >= 1 && userInt <= 100)
                {
                    // between 1 and 100
                    return true;
                }
                else
                {
                    // not between 1 and 100
                    return false;
                }

            }
            else
            {
                // not a number
                return false;
            }
        }

        public static void SetNumberToGuess(int number)
        {
            //TODO: make this function override your global variable holding the number the user needs to guess.  This is used only for testing methods.
            NumberToGuess = number;
        }

        public static bool IsGuessTooHigh(int userGuess)
        {
            //TODO: return true if the number guessed by the user is too high
            return userGuess > NumberToGuess;
        }

        public static bool IsGuessTooLow(int userGuess)
        {
            //TODO: return true if the number guessed by the user is too low
            return userGuess < NumberToGuess;
        }
    }
}
