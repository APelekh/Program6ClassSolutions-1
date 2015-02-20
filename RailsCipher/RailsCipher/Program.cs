using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework; //using statement for NUnit to work

namespace RailsCipher
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Encrypt(17, "nickleback"));
            Console.WriteLine(Decrypt(17, "nlcikeakcb"));

            Console.WriteLine(Decrypt(17, Encrypt(17, "i love biscuits and gravy.  especially on sunday mornings.  man its soooo sweet.  whos down for the biscuit co yall?")));
            var rails = new RailFenceCipher();
            rails.Encrypt("nickleback", 3);
        }

        static string Encrypt(int numberOfLines, string textToEncrypt)
        {
            List<string> listOfStrings = new List<string>();
            for (int i = 0; i < numberOfLines; i++)
            {
                listOfStrings.Add(string.Empty);
            }

            //represents what line to add a character to
            int currentLine = 0;

            string direction = "down";


            //loop over each letter
            foreach (char letter in textToEncrypt)
            {
                //add that letter to the current line
                listOfStrings[currentLine] += letter.ToString();

                if (currentLine == (listOfStrings.Count - 1))
                {
                    //checking to see if we're at the last line
                    direction = "up";
                }
                else if (currentLine == 0)
                {
                    //checking at the first line
                    direction = "down";
                }

                //figure out how to increment our counter
                if (direction == "down")
                {
                    currentLine++;
                }
                else
                {
                    //we are going up
                    currentLine--;
                }
            }

            return string.Join("", listOfStrings);

            //string returnString = string.Empty;
            //foreach (string line in listOfStrings)
            //{
            //    returnString += line;
            //}

        }
        static string Decrypt(int numberOfLines, string textToDecrypt)
        {
            //step 1. figure out how many characters in each line

            List<string> listToFigureOutHowManyCharactersPerLine = new List<string>(); // stores the characters for step 1
            List<string> listOfStringsToDecrypt = new List<string>(); //stores the characters for step 2
            for (int i = 0; i < numberOfLines; i++)
            {
                listToFigureOutHowManyCharactersPerLine.Add(string.Empty);
                listOfStringsToDecrypt.Add(string.Empty);
            }

            //represents what line to add a character to
            int currentLine = 0;

            string direction = "down";


            //loop over each letter
            foreach (char letter in textToDecrypt)
            {
                //add that letter to the current line
                listToFigureOutHowManyCharactersPerLine[currentLine] += letter.ToString();

                if (currentLine == (listToFigureOutHowManyCharactersPerLine.Count - 1))
                {
                    //checking to see if we're at the last line
                    direction = "up";
                }
                else if (currentLine == 0)
                {
                    //checking at the first line
                    direction = "down";
                }

                //figure out how to increment our counter
                if (direction == "down")
                {
                    currentLine++;
                }
                else
                {
                    //we are going up
                    currentLine--;
                }
            }


            //at this point, we know how many characters per line, given the length of the text to decrypt

            //step 2. take a substring of characters from the text to decrypt and put it in to a list
            //populate the listOfStringsToDecrypt
            //loop through the listToFigureOutHowManyCharactersPerLine to populate the listOfStringsToDecrypt
            int startIndex = 0;
            int currentLineToPopulate = 0;
            foreach (string line in listToFigureOutHowManyCharactersPerLine)
            {
                int numberOfCharacters = line.Length;
                string originalLettersInTheLine = textToDecrypt.Substring(startIndex, numberOfCharacters);
                startIndex += numberOfCharacters;

                listOfStringsToDecrypt[currentLineToPopulate] = originalLettersInTheLine;
                currentLineToPopulate++;
            }

            //our listOfStringsToDecrypt has the proper characters in the correct lines that they were when they were encrypted

            //step 3. walk through that list using the same zig/zag pattern to reconstruct the original word
            //represents what line to add a character to
            currentLine = 0;

            direction = "down";

            string returnString = string.Empty;

                for (int i = 0; i < textToDecrypt.Length; i++)
                {
                    //do this operation once for each character
                    //add the character of whatever line we're currently on
                    returnString += listOfStringsToDecrypt[currentLine][0];
                    //remove the character from whatever line we're currently on
                    listOfStringsToDecrypt[currentLine] = listOfStringsToDecrypt[currentLine].Remove(0, 1);
                    if (currentLine == (listOfStringsToDecrypt.Count - 1))
                    {
                        //checking to see if we're at the last line
                        direction = "up";
                    }
                    else if (currentLine == 0)
                    {
                        //checking at the first line
                        direction = "down";
                    }

                    //figure out how to increment our counter
                    if (direction == "down")
                    {
                        currentLine++;
                    }
                    else
                    {
                        //we are going up
                        currentLine--;
                    }
                }

                return returnString;
        }


   
    }

    /// <summary>
    /// Encrypts and decrypts a string using the "Rail Fence Cipher" method
    /// </summary>
    class RailFenceCipher
    {
        int counter = 1;
        //used to change the direction of the counter (from adding to subtracting and back again)
        int direction = -1;

        //Constructor
        public RailFenceCipher() { }

        /// <summary>
        /// Encrypt the input string based on a number of lines (zig-zag height)
        /// </summary>
        /// <param name="textToEncrypt">text to encrypt</param>
        /// <param name="numLines">height of zig-zag</param>
        /// <returns>encrypted text</returns>
        public string Encrypt(string textToEncrypt, int numLines)
        {
            //initialize variables
            int lineInFocus = 0;
            int currentLine = 0;
            //return string to hold letters at they encrypted
            string encryptedText = string.Empty;

            //process each line in zig-zag one at a time until all have been completed
            while (lineInFocus < numLines)
            {
                //start at the first (highest) line
                currentLine = 0;
                this.counter = 1;
                //loop through every letter in the string
                for (int i = 0; i < textToEncrypt.Length; i++)
                {
                    //if letter in string exists in the current horizontal line being analyzed (lineInFocus) add it to the return string
                    if (currentLine == lineInFocus)
                    {
                        encryptedText += textToEncrypt[i];
                    }
                    //move to the next horizontal line
                    currentLine += this.counter;
                    //keep the currentLine within the height constrains of the zig-zag, change its direction up or down as needed
                    if (currentLine <= 0 || currentLine >= numLines - 1)
                    {
                        this.counter *= this.direction;
                    }
                }
                //after anazlying entire string move onto the next horizontal line to focus on and pick letters from
                lineInFocus++;
            }
            return encryptedText;
        }

        /// <summary>
        /// Decrypt the input string based on a number of lines (zig-zag height)
        /// </summary>
        /// <param name="textToDecrypt">text to decrypt</param>
        /// <param name="numLines">height of zig-zag</param>
        /// <returns>decrypted text</returns>
        public string Decrypt(string textToDecrypt, int numLines)
        {
            //initialize variables
            int lineInFocus = 0;
            int currentLine = 0;
            //return string to hold decrypted letter (needs to have length established at beginning and equal to encrypted input string)
            string decryptedText = textToDecrypt;
            //used to step through letters of encrypted input string one at a time
            int letterStepper = 0;
            //process each line in zig-zag one at a time until all have been completed
            while (lineInFocus < numLines)
            {
                //start at the first (highest) line
                currentLine = 0;
                this.counter = 1;
                //loop through every letter in the string
                for (int i = 0; i < textToDecrypt.Length; i++)
                {
                    //if letter in string exists in the current horizontal line being analyzed (lineInFocus)...
                    if (currentLine == lineInFocus)
                    {
                        //insert the current letter of encrypted input text (based on letterStepper) into the return string at the index where it exists in the zig-zag...hard to explain in words
                        decryptedText = decryptedText.Insert(i, textToDecrypt[letterStepper].ToString());
                        //using Insert pushes all letters in return string forward by one, so remove the proceeding index to maintain original length
                        decryptedText = decryptedText.Remove(i + 1, 1);
                        //advance the letterstepper to use the next letter in the encrypted input string
                        letterStepper++;
                    }
                    //move to the next horizontal line
                    currentLine += this.counter;
                    //keep the currentLine within the height constrains of the zig-zag, change its direction up or down as needed
                    if (currentLine <= 0 || currentLine >= numLines - 1)
                    {
                        this.counter *= this.direction;
                    }
                }
                //after anazlying entire string move onto the next horizontal line to focus on and pick letters from
                lineInFocus++;
            }
            return decryptedText;
        }

    }


    //Create our test class
    [TestFixture]
    class Test
    {
        [Test]
        public void SomeTest()
        {
            Assert.IsTrue("Andrii is awesome" == "Andrii is awesome");
        }
    }
}
