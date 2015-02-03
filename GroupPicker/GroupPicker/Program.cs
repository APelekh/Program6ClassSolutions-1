using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupPicker
{
    class Program
    {
        static void Main(string[] args)
        {
            //new list to hold the student
            List<string> studentList = new List<string>();
            //populating that list with strings (mine are numbers, you'll use names)
            for (int i = 1; i <= 17; i++) { studentList.Add(i.ToString()); }

            //function call for groups of 3
            int groupsize = 4;
            PickGroups(studentList, groupsize);


            Console.ReadKey();
        }

        /// <summary>
        /// Randomly pick groups from a list of students
        /// </summary>
        /// <param name="studentList">the list of students</param>
        /// <param name="groupSize">the size of each group</param>
        static void PickGroups(List<string> studentList, int groupSize)
        {

            //rng for picking a random student
            Random rng = new Random();
            //list to hold the current group we are assigning
            List<string> currentGroupList = new List<string>();
            //int to hold the current group number
            int groupNumber = 1;

            while (studentList.Count > 0)
            {
                //pick a random number to serve as our index when selecting a random student
                int randomIndex = rng.Next(0, studentList.Count);
                //use the randomIndex to get a random student from the list
                string randomStudent = studentList[randomIndex];
                //add the randomStudent to the currentGroupList
                currentGroupList.Add(randomStudent);
                //remove the randomStudent from the studentList
                studentList.Remove(randomStudent);
                //check to see if the group is full or there are no more students to assign
                if (currentGroupList.Count == groupSize || studentList.Count == 0)
                {
                    //Write the group header
                    Console.WriteLine("Group {0}", groupNumber);
                    
                    //string.Join makes it easier to write lists to the console. string.join takes two parameters, the first is the seperator between items, using "\n" means new line.  The second parameter is an IEnumerable.  IEnumerable is an interface (which we'll discuss later), but it means that both Lists and Arrays can be used. A string is automatically generated.
                    Console.WriteLine(string.Join("\n", currentGroupList));
                    
                    ////old way of writing out the student names
                    //for (int i = 0; i < currentGroupList.Count; i++)
                    //{
                    //    Console.WriteLine(currentGroupList[i]);
                    //}

                    //inserting a blank line for readability
                    Console.WriteLine();
                    //clear the currentGroupList for the next group
                    currentGroupList.Clear();
                    //increment the groupNumber for the next group
                    groupNumber++;
                }
            }
        }
    }
}
