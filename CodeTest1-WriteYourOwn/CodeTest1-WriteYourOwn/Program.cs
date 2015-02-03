using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTest1_WriteYourOwn
{
    class Program
    {
        static void Main(string[] args)
        {
            FlipThreeHeadsInARow();
            Console.ReadKey();
        }

        static void TCounter(string inputString)
        {
            int numberOfTs = 0;
            for (int i = 0; i < inputString.Length; i++)
            {
                if (inputString[i].ToString().ToLower() == "t")
                {
                    numberOfTs++; //found a t, count it
                }

                //to check a char to a char
                //if (char.ToLower(inputString[i]) == 't')
                //{
                //    numberOfTs++;
                //}
            }
            //loop complete
            Console.WriteLine("There are {0} in the string {1}", numberOfTs, inputString);
        }

        static int Divider(int number1, int number2)
        {
            if (number1 == 0 || number2 == 0)
            {
                return 0;
            }
         
            return number1 / number2;
         
        }

        static void DrainTank(string name) { }

        static void CheckTank(double currentVolume, double maxVolume, string tankName)
        {
            if (currentVolume >= (maxVolume * .8))
            {
                DrainTank(tankName);               
            }
        }

        static int CountWords(string inputString)
        {
            List<string> words = inputString.Split(' ').ToList();
            return words.Count;

            //one line soluction
            //return inputString.Split(' ').Length;
        }

        static void FlipThreeHeadsInARow()
        {
            int totalNumberOfFlips = 0;
            int numberOfHeadsInARow = 0;
            Random rng = new Random();

            while (numberOfHeadsInARow < 3)
            {
                int flipResult = rng.Next(0, 2);
                totalNumberOfFlips++;

                if (flipResult == 1)
                {
                    //heads
                    numberOfHeadsInARow++;
                } 
                else 
                {
                    numberOfHeadsInARow = 0;
                }
            }
            //flipping finished
            Console.WriteLine("It took {0} flips to flip three heads in a row", totalNumberOfFlips);
        }
    }
}
