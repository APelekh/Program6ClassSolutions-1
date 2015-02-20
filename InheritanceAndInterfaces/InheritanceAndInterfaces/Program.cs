using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceAndInterfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            //Employee JohnMcClary = new Employee("John", "McClary", "Known Liar");
            //JohnMcClary.Talk();

            //Janitor jeff = new Janitor("jeff", "macco");
            //jeff.Sweep();
            //jeff.Clean();
            //jeff.Talk();

            Musician Laura = new Musician("Laura", "Boyd", "Piano");
            //Laura.Talk();
            //Laura.Jam();
            //Laura.Walk();

            Bird bird = new Bird();

            List<ISing> listOfThingsThatSing = new List<ISing>();
            listOfThingsThatSing.Add(Laura);
            listOfThingsThatSing.Add(bird);

            foreach (ISing somethingThatSings in listOfThingsThatSing)
            {
                somethingThatSings.Sing();
            }


            Console.ReadKey();
        }
    }

    //regions are great for hiding stuff
    #region " Inheritance stuff "

    //abstract class: cannot be instantiated
    public abstract class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Person(string fname, string lname)
        {
            this.FirstName = fname; this.LastName = lname;
        }

        //methods
        public void Walk()
        {
            Console.WriteLine("whistling sounds");
        }

        //need virtual because we are overriding the behavior of this method in a child class
        public virtual void Talk()
        {
            Console.WriteLine("Hey whats up?");
        } 
    }

    //employee inherits the person class
    public class Employee : Person
    {
        public string JobTitle { get; set; }

        public Employee(string fname, string lname, string jobTitle) : base(fname, lname)
        {
            this.JobTitle = jobTitle;
        }

        //methods
        //override, overrides the base class method
        public override void Talk()
        {
            //if we want to include the base class behavior
            base.Talk();
            //talk about the job
            Console.WriteLine("I'm a {0}.  Synergize the paradigm.", this.JobTitle);
        }
    }

    public class Janitor : Employee
    {
        public int NumberOfBrooms { get; set; }

        public Janitor(string fname, string lname)
            : base(fname, lname, "Janitor")
        {
            //nothing goes in the constructor, because the base classes handle it for us
            this.NumberOfBrooms = 3;
        }

        //methods

        public override void Talk()
        {
            base.Talk();
            Console.WriteLine("I'm a person too.");
        }

        public void Sweep()
        {
            Console.WriteLine("sweep sweep sweep");
        }

        public void Clean()
        {
            Console.WriteLine("squeaky squeaky");
        }
    }

    //musician can talk about the instrument he plays, and jam
    public class Musician : Employee, ISing
    {
        public string Instrument { get; set; }

        public Musician(string fname, string lname, string instrument)
            : base(fname, lname, "Musician")
        {
            this.Instrument = instrument;
        }

        public override void Talk()
        {
            base.Talk();
            Console.WriteLine("I like to wail on my {0}", this.Instrument);
        }

        public void Jam()
        {
            Console.WriteLine("Jamming on my {0}.  Oh yeah, jam it all day.", this.Instrument);
        }

        public void Sing()
        {
            Console.WriteLine("whooooooooooooa-oh-oh sweet child of miiiiiine");
        }
    }
#endregion

#region "Interfaces" 
    
    interface ISing
    {
        //framework for describing something that sings
        // provides no information on how it sings (does not implement how it sings)
        void Sing();
    }

    class Bird : ISing
    {

        public void Sing()
        {
            Console.WriteLine("chirp chirp chirp");
        }
    }

    interface ICombustionEngine
    {
        int FuelLevel { get; set; }
        void Refuel(int fuel);
        void Go();
    }

    interface IVehicle
    {
        int Velocity { get; set; }
    }

    interface IPowerOutput
    {
        int KilowattsGenerated { get; set; }
    }

    public class Jet : ICombustionEngine, IVehicle
    {
        public int Velocity { get; set; }
        public int FuelLevel { get; set; }

        public void Refuel(int fuel)
        {
            this.FuelLevel += fuel;
        }

        public Jet()
        {
            this.FuelLevel = 20;
        }

        public void Go()
        {
            if (FuelLevel > 25)
            {
                Console.WriteLine("vrooom!  breaking sound barriers yo");
                this.Velocity += 400;
                this.FuelLevel -= 25;
            }
            else
            {
                Console.WriteLine("out of gas");
            }
        }
     }

    public class Generator : ICombustionEngine, IPowerOutput
    {

        public int FuelLevel { get; set; }
        public Generator()
        {
            this.FuelLevel = 20;
        }
        public void Refuel(int fuel)
        {
            this.FuelLevel += fuel;
        }

        public void Go()
        {
            if (this.FuelLevel > 10)
            {
                Console.WriteLine("I'm producing 25 KW");
                this.KilowattsGenerated += 25;
                this.FuelLevel -= 10;
            }
            else
            {
                Console.WriteLine("out of gas");
            }
        }

        public int KilowattsGenerated
        {
            get;
            set;
        }
    }

#endregion
}
