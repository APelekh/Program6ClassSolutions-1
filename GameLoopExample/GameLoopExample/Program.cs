using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLoopExample
{
    class Program
    {
        static bool gamePlaying = true;
        static Random rng = new Random();
        static string cake = string.Empty;
        static int roundCounter = 1;

        static void Main(string[] args)
        {
            // populate list of cakes
            List<string> cakes = new List<string>() { "vanilla", "chocolate", "yellow", "angel food", "ice cream" };
            // pick one at random to have the user guess
            cake = cakes[rng.Next(0, cakes.Count)];

            while (gamePlaying)
            {
                Console.Clear();
                Console.WriteLine("Guess That Cake!");
                RevealPart();
                GetUserInput();
            }
            // after the game is complete, give them some results
            Console.WriteLine("You guessed the cake was {0}. It only took you {1} guesses.", cake, roundCounter);
            Console.ReadKey();
        }
        static void RevealPart()
        {
            // reveal part of the cake's name one character at a time
            Console.WriteLine("A hint: {0}", cake.Substring(0, roundCounter));

        }
        static void GetUserInput()
        {
            // Ask for user input
            Console.Write("Guess a cake: ");
            string userInput = Console.ReadLine();

            // validate input
            bool validInput = true;
            for (int i = 0; i < userInput.Length; i++)
            {
                if ("abcdefghijklmnopqrstuvwxyz ".Contains(userInput[i]) && validInput == true)
                {

                }
                else
                {
                    validInput = false;
                }
            }
            
            // we have valid input
            if (validInput)
            {
                // is the user guess the answer
                if (userInput.ToLower().Replace(" ", string.Empty) == cake.ToLower().Replace(" ", string.Empty))
                {
                    // the guessed correctly
                    gamePlaying = false;
                }
                else
                {
                    // incorrect
                    Console.WriteLine("Incorrect guess");
                    System.Threading.Thread.Sleep(2000);
                    roundCounter++;
                }
            }
        }
    }
}
