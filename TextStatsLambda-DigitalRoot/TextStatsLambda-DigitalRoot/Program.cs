using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextStatsLambda_DigitalRoot
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(DigitalRoot("31337"));
            Console.ReadKey();
        }

        public static int DigitalRoot(string rootThisNumber)
        {
            //input: "1234987"
            //integer to hold our total
            int totalSum = 0;

            while (rootThisNumber.Length > 1)
            {
                //sum up the digits together
                totalSum = rootThisNumber.Sum(x => int.Parse(x.ToString()));

                //what the .sum() extension actually does
                //int sum = 0;
                //for (int i = 0; i < rootThisNumber.Length; i++)
                //{
                //    char x = rootThisNumber[i];
                //    sum += int.Parse(x.ToString());
                //}
                //return sum;
                rootThisNumber = totalSum.ToString();
            }
            return int.Parse(rootThisNumber);
        }


        public static int NumberOfWords(string inputString)
        {
            return inputString.Replace("  ", " ").Split(' ').Length;
        }

        public static int NumberOfVowels(string inputString)
        {
            return inputString.Count(x => "aeiou".Contains(x.ToString().ToLower()));

            // this is what a lambda expression actually does
            //int count = 0;
            //for (int i = 0; i < inputString.Length; i++)
            //{
            //    char x = inputString[i];
            //    if ("aeiou".Contains(x.ToString().ToLower()))
            //    {
            //        count++;
            //    }
            //}
            //return count;
        }

        /// <summary>
        /// how a .Where() lambda expression actually works
        /// </summary>
        /// <param name="inputList"></param>
        /// <returns></returns>
        public List<string> WhereLambdaExplanation(List<string> inputList)
        {
            //return inputList.Where(x => x.Length > 5).ToList();

            List<string> returnList = new List<string>();
            for (int i = 0; i < inputList.Count; i++)
            {
                string x = inputList[i];
                if (x.Length > 5)
                {
                    //passed the condition, add to the return list
                    returnList.Add(x);
                }
            }
            return returnList;
        }

        public static int NumberOfConsonants(string inputString)
        {
            return inputString.Count(x => !"aieou .,?;'!@#$%^&*()".Contains(x.ToString().ToLower()));
        }

        public static int NumberOfSpecialCharacters(string inputString)
        {
            // .,?;'!@#$%^&*() and spaces are considered special characters
            return inputString.Count(x => ".,?;'!@#$%^&*() ".Contains(x.ToString().ToLower()));
        }

        public static string LongestWord(string inputString)
        {
            return inputString.Split(' ').OrderByDescending(x => x.Length).First();
        }

        public static string ShortestWord(string inputString)
        {
            return inputString.Split(' ').OrderBy(x => x.Length).First();
        }


    }
}
