using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextStatsObject
{
    class Program
    {
        static void Main(string[] args)
        {
            TextStats ts1 = new TextStats("eric really likes oddessa.");
            TextStats ts2 = new TextStats("aint no party like a pfunk party.  cuz a pfunk party don't stop.");

            List<TextStats> textStatList = new List<TextStats>();
            textStatList.Add(ts1); textStatList.Add(ts2);

            textStatList.Where(x => x.LongestWord.Length > 15);
            //ts1.PrintStats();
            Console.ReadKey();
        }
    }

    class TextStats
    {

        //string to process

        private string _inputstring;

        public string InputString
        {
            get { return _inputstring; }
            set { _inputstring = value; }
        }
        

        public int NumberOfCharacters
        {
            get { return this.InputString.Length; }
        }

        public int NumberOfVowels
        {
            get { return this.InputString.Count(x => "aeiou".Contains(x.ToString())); }
        }

        public int NumberOfConsonants
        {
            get { return this.InputString.Count(x => !"aeiou .?'!@#$%^^&&())".Contains(x.ToString())); }
        }

        public int NumberOfSpecialCharacters
        {
            get { return this.InputString.Count(x => " .?'!@#$%^^&&())".Contains(x.ToString())); }
        }

        public int NumberOfWords 
        {
            get { return this.InputString.Split(' ').Length; }
        }

        public string LongestWord
        {
            get { return this.InputString.Split(' ').OrderBy(x => x.Length).Last(); }
        }

        public TextStats(string inputString)
        {
            this.InputString = inputString;
        }

        public void print()
        {
            Console.WriteLine(@"Stats! 
{0}
{1}
{2}");
        }

        
    }
}
