using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlipMania
{
    class Program
    {
        public static Random rng = new Random();
        static void Main(string[] args)
        {
            FlipCoins(10000);
            FlipForHeads(10000);
            // keep the console open
            Console.ReadKey();
        }
        /// <summary>
        /// Flip a coin a number of times and write the result to the console
        /// </summary>
        /// <param name="numberOfFlips">how many coin flips</param>
        static void FlipCoins(int numberOfFlips)
        {
            // check for valid input
            if (numberOfFlips > 0)
            {
                int numberOfHeads = 0;
                int numberOfTails = 0;

                // Flip a number of times
                for (int i = 0; i < numberOfFlips; i++)
                {
                    // determine head's or tails and record it
                    if (rng.Next(0, 2) == 0)
                    {
                        // heads
                        numberOfHeads++;
                    }
                    else
                    {
                        // tails
                        numberOfTails++;
                    }
                }

                // write the results to the console
                Console.WriteLine("We flipped a coin " + numberOfFlips + " times.");
                Console.WriteLine("Number of heads: " + numberOfHeads);
                Console.WriteLine("Number of tails: " + numberOfTails);
            }
        }
        static void FlipForHeads(int numberOfHeads)
        {
            //check for valid input 
            if (numberOfHeads > 0)
            {
                int numberOfHeadsFlipped = 0;
                int totalFlips = 0;
                
                //Flip until there are enough heads found
                while (numberOfHeadsFlipped <= numberOfHeads)
                {
                    // incrementing if there is a head found
                    if (rng.Next(0, 2) == 0)
                    {
                        // heads
                        numberOfHeadsFlipped++;
                    }
                    totalFlips++;
                }

                // write the output to the console
                Console.WriteLine("We are flipping a coin until we find " + numberOfHeads + " heads");
                Console.WriteLine("It took " + totalFlips + " to find " + numberOfHeads + " heads");
            }
        }
    }
}
