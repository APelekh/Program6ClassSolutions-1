using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesAndObjects_StudentCourses
{
    class Program
    {
        static void Main(string[] args)
        {
   

            DoStudentExamples();
 
            //ShowCourseConstructors();
            Console.ReadKey();
        }

        static void DoStudentExamples()
        {
            
            Student student1 = new Student("John McClary", StudentRank.Senior);
            student1.CourseList.Add(new Course("Prof Development", "B"));
            student1.CourseList.Add(new Course("Programming", "D"));
            student1.CourseList.Add(new Course("Hockey History 101", "A"));
            student1.CourseList.Add(new Course("Being named John", "F"));

            student1.PrintStudentInfo();

            Student student2 = new Student("Nicole Wino", StudentRank.Junior);
            student2.CourseList.Add(new Course("Prof Development", "A"));
            student2.CourseList.Add(new Course("Programming", "C"));
            student2.CourseList.Add(new Course("Hockey History 101", "A"));
            student2.CourseList.Add(new Course("Being named John", "A"));

            student2.PrintStudentInfo();

            List<Student> studentList = new List<Student>();
            studentList.Add(student1);
            studentList.Add(student2);

            var onlyJuniors = studentList
                .Where(x => x.StudentRank == (StudentRank)3);

            IEnumerable<Student> smartPeople = studentList.Where(x => x.GPA > 3.5);

            List<string> smartPeopleNames = studentList.Where(x => x.GPA > 3.5).Select(x => x.Name).ToList();

            var somethign = studentList.Count(x => x.GPA > 3.5 && x.Name.Contains("John"));

            var listOfStrings = new List<string>();
            var longStringsWithJohn = listOfStrings.Count(x => x.Length > 5 && x.Contains("John"));


            var studentsThatHaveTakenProgramming = studentList.Where(x => x.CourseList.Any(y => y.Name == "Programming"));
            
        }

        static void ShowCourseConstructors() 
        {
            Course course1 = new Course();
            Course course2 = new Course("Biology");
            Course course3 = new Course("Math 101", "A");

            course1.PrintCourseInfo();
            course2.PrintCourseInfo();
            course3.PrintCourseInfo();

            course2.LetterGrade = "B";
            course2.PrintCourseInfo();

        }

        //new function here
    }

    //new classes go here
    public class Course
    {
        //STEP 1. Define properties
        
        //CREATING PROPERTIES:
        // STEP 1: Create the hide-behind variable
        private string _name;
        // STEP 2: Create the property layer that sits on top of that variable.  It controls the interaction with the variable
        public string Name
        {
            get
            {
                //Getter: whenever the property is on the right side of an equation, this code is run.
                // eg. myString = myObject.Name;
                return _name.ToUpper();
            }
            set
            {
                //Setter: whenever the property is on the left side of an equation, this code is run
                // eg. myObject.Name = "Nickleback";
                _name = value;
            }
        }

        private string _letterGrade;
        public string LetterGrade
        {
            get { return _letterGrade; }
            set { _letterGrade = value.ToUpper(); }
        }

        //for the Grade Points, we are going to do a READ-ONLY property
        public double GradePoints
        {
            get
            {
                switch (this.LetterGrade)
                {
                    case "A":
                        return 4.0;
                    case "B":
                        return 3.0;
                    case "C":
                        return 2.0;
                    case "D":
                        return 1.0;
                    default:
                        return 0.0;
                }
            }
        }

        //Creating a new class: STEP 2: Define constructor(s)
        
        //Parameterless constructor, think of it as our "default constructor"
        public Course()
        {
            this.Name = "Undefined";
            this.LetterGrade = "I";
        }

        //Parameterfull constructor, more common, this is the constructor you'll usually use
        public Course(string name)
        {
            this.Name = name;
            this.LetterGrade = "I";
        }

        public Course(string name, string letterGrade)
        {
            this.Name = name;
            this.LetterGrade = letterGrade;
        }

        //Creating a new class: STEP 3: Define its Methods (actions)
        public void PrintCourseInfo()
        {
            Console.WriteLine("{0, 20} {1, 2} {2, 3}", this.Name, this.LetterGrade, this.GradePoints);
        }

    }


    //DEFINING AN ENUMERATION (ENUM)
    public enum StudentRank
    {
        Freshman,
        Sophmore,
        Junior,
        Senior
    }

  

    public class Student
    {

        //step 1: define properties
        private string _name;
        public string Name
        {
            get { return _name; } //e.g. Console.Write(myObj.Name);
            set { _name = value; } //e.g. myObj.Name = "Patrick Yee";
        }

        private List<Course> _courseList;
        public List<Course> CourseList
        {
            get { return _courseList; }
            set { _courseList = value; }
        }

        public double GPA
        {
            get
            {
                //total grade points, divided by # of classes
                return this.CourseList.Average(x => x.GradePoints);

                //whats going on with the .Average() extension
                //double totalSum = 0.0;
                //for (int i = 0; i < this.CourseList.Count; i++)
                //{
                //    Course x = this.CourseList[i];
                //    totalSum += x.GradePoints;
                //}
                //return totalSum / this.CourseList.Count;
            }
        }

        private StudentRank _studentRank;
        public StudentRank StudentRank
        {
            get { return _studentRank; }
            set { _studentRank = value; }
        }

        //shorthand property declaration
        //public StudentRank StudentRank { get; set; }

        //other properties might include: age, studentID, DOB, major, ClassRank, Drink Pref, Gender
 
        //STEP 2: CONSTRUCTORS!!!
        public Student(string name, StudentRank rank)
        {
            this.Name = name;
            this.CourseList = new List<Course>(); //make sure to initialize any lists
            this.StudentRank = rank;
        }

        //Step 3: METHODS
        public void PrintStudentInfo()
        {
            Console.WriteLine("Name: {0}", this.Name);
            
            foreach (Course course in this.CourseList)
            {
                course.PrintCourseInfo();
            }
            //does the same as a lambda
            //this.CourseList.ForEach(x => x.PrintCourseInfo());
            
            Console.WriteLine("GPA: {0}", this.GPA);
        }
    }

}
