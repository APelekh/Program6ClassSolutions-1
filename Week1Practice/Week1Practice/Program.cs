using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week1Practice
{
    class Program
    {
        static void Main(string[] args)
        {
            // DECLARING VARIABLES
            // 1. Declare a string variable called "myName" and set it equal to your name
            string myName = "Eric";
            // 2. Declare a number varible called "myAge" and set it equal to your age
            int myAge = 26;
            // 3. Declare a boolean value called "myBool" and set it equal to true or false;
            bool myBool = true;
            // 4. Declare a new list of strings called "productsList" and set it equal to "basketball", "baseball glove", "tennis shoes", "hockey puck"
            List<string> productList = new List<string>() { "basketball", "baseball glove", "tennis shoes", "hockey puck" };

            // PRINTING VARIABLES TO THE CONSOLE USING CONSOLE.WRITELINE()
            // 1. Print your name to the console using the format: "My name is <myName> and I'm a beast of a programmer"
            Console.WriteLine("My name is " + myName + " and I'm a beast of a programmer");
            // 2. Print out your age to the console using the format: "I am <myAge> years awesome."
            Console.WriteLine("I am " + myAge + " years awesome");
            // 3. Print out your boolean value using the format: "I set my boolean value equal to <myBool>"
            Console.WriteLine("I set my boolean value equal to " + myBool);
            // 4. Using a For loop, print out each value in productsList.
            for (int i = 0; i < productList.Count; i++)
            {
                Console.WriteLine(productList[i]);
            }

            // FOR LOOP PRACTICE
            // 1. Create a for loop that prints out the numbers 1 to 10.
            for (int i = 1; i < 11; i++)
            {
                Console.WriteLine(i);
            }
            // 2. Create a for loop that prints out the numbers 10 to 1.
            for (int i = 10; i > 0; i--)
            {
                Console.WriteLine(i);
            }
            // 3. Create a for loop that prints out the numbers 10 to 30, only printing the even numbers
            for (int i = 10; i < 31; i += 2)
            {
                Console.WriteLine(i);
            }
            // 4. Create a for loop that prints out the numbers 100 to 75, only printing every 5th number (100, 95, 90, 85, 80, 75)
            for (int i = 100; i >= 75 ; i -= 5 )
            {
                Console.WriteLine(i);
            }

            // WHILE LOOP PRACTICE
            int counter = 1;
            // 1. Create a while loop that prints out the numbers from 1 to 10.
            while (counter < 11)
            {
                Console.WriteLine(counter);
                counter++;
            }

            // 2. Create a while loop that prints out the numbers from 10 to 1.
            counter = 10;
            while (counter > 0)
            {
                Console.WriteLine(counter);
                counter--;
            }
            // 3. Create a while loop that prints out the numbers from 15 to 30, only printing the even numbers
            counter = 15;
            while (counter < 31)
            {
                // only even
                if (counter % 2 == 0)
                {
                    Console.WriteLine(counter);
                }
                counter++;
            }
            // 4. Create a while loop that prints out the numbers from 100 to 75, only printing every 5th number (100, 95, 90, 85, 80, 75)
            counter = 100;
            while (counter >= 75)
            {
                Console.WriteLine(counter);
                counter -= 5;
            }
            // 5. Create a while loop that prints out the numbers from 1 to 10 until it reaches one that is divisible by 4.
            counter = 1;
            while (counter % 4 != 0)
            {
                Console.WriteLine(counter);
                counter++;
            }

            // PUTTING IT TOGETHER
            // Use either FOR or WHILE loops to accomplish the following:
            // 1. Print out the number of letters in your name using the format: "My name, <myName>, has <number of letters> in it."
            int nameLetters = 0;
            for (int i = 0; i < myName.Length; i++)
            {
                nameLetters++;
            }
            Console.WriteLine("My name, "+myName+", has "+ nameLetters + " in it.");
            // 2. Print out the number of items in your list using the format: "My product list has <number of items> in it."
            int listItemsNumber = 0;
            for (int i = 0; i < productList.Count; i++)
            {
                listItemsNumber++;
            }
            Console.WriteLine("My product list has "+ listItemsNumber+ " in it.");
            // 3. Print out the number of letters of each item in productsList using the format: "<product> has <number of letters> in it."
            for (int i = 0; i < productList.Count; i++)
            {
                Console.WriteLine(productList.ElementAt(i) + " has " + productList.ElementAt(i).Length + " in it.");
            }

            // DECLARING AND CALLING FUNCTIONS
            // 1. Create a function called "Greeting" that takes one string parameter called "name".  This function will print "Hello <name>"
            
            // 2. Call the Greeting function by passing in "Geronimo Jackson" as your parameter.
            Greeting("Geronimo Jackson");
            // 3. Call the Greeting function by passing in myName as your parameter.
            Greeting(myName);

            // 4. Create a function called "DoubleIt" that takes one integer parameter called "number".  This function will print "<number> doubled is <number * 2>"

            // 5. Call your DoubleIt Function by passing in 1337 as your parameter.
            DoubleIt(1337);
            // 6. Call your DoubleIt function by passing in myAge as your parameter.
            DoubleIt(myAge);

            // 7. Create a function called "Multiply" that takes two integer parameters called "num1" and "num2".  This function will print "<num1> times <num2> is <num1 * num2>"
            // 8. Call your Multiply function by passing in 2 and 8 as your parameters.
            Multiply(2, 8);
            // 9. Call your Multiply function by passing in 3 and myAge as your parameters.
            Multiply(3, myAge);

            // 10. Create a function called "LoopThis" that takes two integer parameters called "startNum" and "endNum".  
            //      This function will print out: 
            //          a. "I'm looping from <startNum> to <endNum>."  
            //          b. The numbers from startNum to endNum, one per line.
            // 11. Call your LoopThis function by passing in 20 and 30 as your parameters.
            LoopThis(20, 30);
            // 12. Call your LoopThis function by passing in 0 and myAge as your parameters.
            LoopThis(0, myAge);

            // 13. Create a function called "SuperLoop" that takes three integer parameters called "startNum", "endNum", and "increment".  
            //      You will need to track how many times the loop has been executed in a variable called "loopCount".
            //      This function will print out: 
            //          a. "I'm looping from <startNum> to <endNum>, incrementing <increment> each time"  
            //          b. The numbers from startNum to endNum, one per line.
            //          c. "That loop was craaaaaazy, we looped X times"
            // 14. Call your SuperLoop function by passing in 0, 100, and 15 as your parameters.
            SuperLoop(0, 100, 15);
            // 15. Call your SuperLoop function by passing in 0, 200, and myAge as your parameters.
            SuperLoop(0, 200, myAge);

            //DECLARING AND CALLING RETURN FUNCTIONS
            // 1. Create a function called "NewGreeting" that takes one string parameter called "name".  This function will return a string in the format of "Hello, <name>"
            // 2. Using your NewGreeting function as the parameter for Console.WriteLine(), call your NewGreeting function using the parameter "Neil deGrasse-Tyson"
            //          EX: Console.WriteLine(FunctionCall("myParameter"));
            Console.WriteLine(NewGreeting("Neil deGrasse-Tyson"));
            // 3. Using your NewGreeting function as the parameter for Console.WriteLine(), call your NewGreeting function using the parameter myName.
            Console.WriteLine(NewGreeting(myName));

            // 4. Create a function called "TripleIt" that takes one integer parameter called "number".  This function will return the number times 3.
            // 5. Using your TripleIt function as part of the parameter for Console.WriteLine(), 
            //      call your TripleIt function using the parameter of 10 to print out "10 tripled is <TripleIt Function Call>"
            Console.WriteLine("10 tripled is "+TripleIt(10));
            // 6. Using your TripleIt function as part of the parameter for Console.WriteLine(), 
            //      call your TripleIt function using the parameter of myAge to print out "<myAge> tripled is <TripleIt Function Call>"
            Console.WriteLine(myAge + " tripled is " + TripleIt(myAge));

            // 7. Create a function called "RealMultiply" that takes two integer parameters called "num1", and "num2".  This function will return the num1 * num2.
            // 8. Using your RealMultiply function as part of the parameter for Console.WriteLine(), 
            //      call your RealMultiply function using the parameter of 5 and 10 to print out the returned value from your function.
            Console.WriteLine(RealMultiply(5, 10));
            // 9. Using your RealMultiply function as part of the parameter for Console.WriteLine(), 
            //      call your RealMultiply function using the parameter of 2 and myAge to print out the returned value from your function.
            Console.WriteLine(RealMultiply(2, myAge));

            //FUNCTION CALL MADNESS!
            // 1. Call your SuperLoop function using the following parameters:
            //      startNum = Call RealMultiply with the parameters 1, 5
            //      endNum = Call TripleIt with the parameter myAge
            //      increment = Call TripleIt with the parameter of myAge minus 10
            SuperLoop(RealMultiply(1,5), TripleIt(myAge),TripleIt(myAge-10));
            // 2. Call your SuperLoop function using the following parameters:
            //      startNum = Call RealMultiply with the parameters 1, and TripleIt with the parameter of 3.
            //      endNum = Call TripleIt with the parameter RealMultiply with the parameters: myAge, 7
            //      increment = Call TripleIt with the parameter of myAge minus RealMultiply with the parameters 2, 4.
            SuperLoop(RealMultiply(1, TripleIt(3)), TripleIt(RealMultiply(myAge, 7)), TripleIt(myAge - RealMultiply(2, 4)));

            Console.ReadKey();
        }

        //START -- FUNCTION DECLARATIONS 

        //Example function declaration
        static void MyFunction(string myParameter)
        {
            //Code block
        }


        static void Greeting(string name)
        {
            Console.WriteLine("Hello " +name);
        }
        static void DoubleIt(int number)
        {
            Console.WriteLine(number + " doubled is "+ (number * 2));
        }
        static void Multiply(int num1, int num2)
        {
            Console.WriteLine("{0} times {1} is {2}", num1, num2, (num1 * num2));
        }
        static void LoopThis(int startNum, int endNum)
        {
            Console.WriteLine("I'm looping from {0} to {1}.", startNum, endNum);
            for (int i = startNum; i <= endNum; i++)
            {
                Console.WriteLine(i);
            }
        }
        static void SuperLoop(int startNum, int endNum, int increment)
        {
            Console.WriteLine("I'm looping from {0} to {1}, incrementing {2} each time", startNum, endNum, increment);
            int loopCounter = 0;
            for (int i = startNum; i <= endNum; i += increment)
            {
                Console.WriteLine(i);
                loopCounter++;
            }
            Console.WriteLine("That loop was craaaaaazy, we looped {0} times", loopCounter);
        }

        static string NewGreeting(string name)
        {
            return "Hello, " + name;
        }
        static int TripleIt(int number)
        {
            return number * 3;
        }
        static int RealMultiply(int num1, int num2)
        {
            return (num1 * num2);
        }
        //END   -- FUNCTION DECLARATIONS
    }
}