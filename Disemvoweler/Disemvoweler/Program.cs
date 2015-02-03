using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disemvoweler
{
    class Program
    {
        static void Main(string[] args)
        {
            Disemvoweler("Nickleback is my Patrick's favorite band.  Their songwriting cannot be beat!");

            Console.ReadKey();
        }

        static string Disemvoweler(string inputString)
        {
            //strings to hold our disemvoweled text and vowels
            string returnString = string.Empty;
            string vowelsString = string.Empty;

            for (int i = 0; i < inputString.Length; i++)
            {
                //looping through each letter of the string
                string letter = inputString[i].ToString();

                //is it a vowel?
                if ("aeiou".Contains(letter.ToLower()))
                {
                    vowelsString += letter;
                }
                else if (" ?.,!!#@$%^%$^&*(".Contains(letter))
                {
                    //do nothing, its a spec char
                }
                else 
                { 
                    //its a consonant
                    returnString += letter;
                }

            }

            //loop complete

            //use the @ to start a multi line string!  ow ow!
            Console.WriteLine(@"
    .___.__                                               .__                
  __| _/|__| ______ ____   ________  ________  _  __ ____ |  |   ___________ 
 / __ | |  |/  ___// __ \ /     \  \/ /  _ \ \/ \/ // __ \|  | _/ __ \_  __ \
/ /_/ | |  |\___ \\  ___/|  Y Y  \   (  <_> )     /\  ___/|  |_\  ___/|  | \/
\____ | |__/____  >\___  >__|_|  /\_/ \____/ \/\_/  \___  >____/\___  >__|   
     \/         \/     \/      \/                       \/          \/       

Orginal: {0}
Disemvoweled: {1}
Vowels Removed: {2}
Have a nice day!", inputString, returnString, vowelsString);
            
            //return the returnString
            return returnString;
        }
    }
}
