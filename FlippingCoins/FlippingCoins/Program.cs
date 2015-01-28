using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlippingCoins
{
    class Program
    {
        static Random randomNumberGenerator = new Random();

        static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(FlipACoin());
            }

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(FlipForHeads());
            }

           


            //keep the window open
            Console.ReadKey();
        }


        /// <summary>
        /// Flips a "coin"
        /// </summary>
        /// <returns>returns a string of either heads or tails</returns>
        static string FlipACoin()
        {
            int theFlip = randomNumberGenerator.Next(0, 2);
            if (theFlip == 0)
            {
                return "Heads";
            }
            return "Tails";
        }

        /// <summary>
        /// Flips a coin until a heads has been flipped
        /// </summary>
        /// <returns>number of tries it took to flip a heads</returns>
        static int FlipForHeads()
        {
            // a "flag" to tell us when to escape the loop
            bool headsHasNotBeenFlipped = true;
            // a counter to hold how many flips we've done
            int howManyFlips = 0;
            //flipping
            while (headsHasNotBeenFlipped)
            {
                //the flip
                string theFlip = FlipACoin();
                //counting the flip we just had
                howManyFlips++;
                if (theFlip == "Heads")
                {
                    //if its a head, kill the loop
                    headsHasNotBeenFlipped = false;
                }
            }
            //return how many flips it took
            return howManyFlips;
        }

    }
}
