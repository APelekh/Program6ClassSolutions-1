using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSV_ListeningHabits
{
    class Program
    {
        // Global List
        public static List<Play> musicDataList = new List<Play>();
        static void Main(string[] args)
        {
            // initalize dataset into list
            InitList();

            //search for total plays of incubus
            Console.WriteLine(TotalPlaysByArtistName("nickelback"));

            TotalPlaysByArtistNameInYear("Skrillex", "2014");


            CountUniqueArtists();


            MostPopularArtistByYear("2014");
            // keep console open
            Console.ReadLine();
        }
        /// <summary>
        /// A function to initalize the List from the csv file
        /// needed for testing
        /// </summary>
        public static void InitList()
        {
            // load data
            StreamReader reader = new StreamReader("scrobbledata.csv");

            // Get and don't use the first line
            string firstline = reader.ReadLine();
            // Loop through the rest of the lines
            while (!reader.EndOfStream)
            {
                string oneLineOfTextFromTheDocument = reader.ReadLine();
                Play aNewPlay = new Play(oneLineOfTextFromTheDocument);
                musicDataList.Add(aNewPlay);
            }

        }
        /// <summary>
        /// A function that will return the total ammount of plays in the dataset
        /// </summary>
        /// <returns>total number of plays</returns>
        public static int TotalPlays()
        {
            return musicDataList.Count;
        }
        /// <summary>
        /// A function that returns the number of plays ever by an artist
        /// </summary>
        /// <param name="artistName">artist name</param>
        /// <returns>total number of plays</returns>
        public static int TotalPlaysByArtistName(string artistName)
        {
            //List<Play> artistOnlyList = musicDataList.Where(x => x.Artist.ToLower() == artistName.ToLower()).ToList();
            //return artistOnlyList.Count;
            return musicDataList.Count(x => x.Artist.ToLower() == artistName.ToLower());
        }
        /// <summary>
        /// A function that returns the number of plays by a specific artist in a specific year
        /// </summary>
        /// <param name="artistName">artist name</param>
        /// <param name="year">one year</param>
        /// <returns>total plays in year</returns>
        public static int TotalPlaysByArtistNameInYear(string artistName, string year)
        {
            List<Play> artistOnlyList = musicDataList.Where(x => x.Artist.ToLower() == artistName.ToLower()).ToList();
            //List<Play> playsByArtistInACertainYear = artistOnlyList.Where(x => x.Time.Year.ToString() == year).ToList();
            //return playsByArtistInACertainYear.Count;

            //List<Play> playsByOnlyTheArtistInACertainYear =
            //    musicDataList.Where(x => x.Time.Year.ToString() == year && x.Artist.ToLower() == artistName.ToLower()).ToList();
            //return playsByOnlyTheArtistInACertainYear.Count;
           
            return musicDataList.Count(x => x.Artist.ToLower() == artistName.ToLower() &&  x.Time.Year.ToString() == year);

            //int count = 0;
            //for (int i = 0; i < musicDataList.Count; i++)
            //{
            //    Play x = musicDataList[i];
            //    if (x.Artist.ToLower() == artistName.ToLower() && x.Time.Year.ToString() == year)
            //    {
            //        count++;
            //    }
            //}
            //return count;

          //what does eric listen to on fridays between noon and 5 pm?
          var theAnswer = musicDataList.Where(x => x.Time.DayOfWeek == DayOfWeek.Friday && x.Time.Hour >= 12 && x.Time.Hour <= 17).GroupBy(x => x.Artist).OrderByDescending(x => x.Count()).ToList();
        }

         

        

        /// <summary>
        /// A function that returns the number of unique artists in the entire dataset
        /// </summary>
        /// <returns>number of unique artists</returns>
        public static int CountUniqueArtists()
        {
            //musicDataList[0].Artist
            List<string> allArtistPlays = musicDataList.Select(x => x.Artist).ToList();
            List<string> allUniqueArtists = allArtistPlays.Distinct().ToList();
            return allUniqueArtists.Count ;
        }


        public static void HowToSelectANewObject()
        {
            List<Play> justAlbumAndArtist = musicDataList.Select(x => new Play(x.Album, x.Artist)).ToList();
        }

        /// <summary>
        /// A function that returns the number of unique artists in a given year
        /// </summary>
        /// <param name="year">year to check</param>
        /// <returns>unique artists in year</returns>
        public static int CountUniqueArtists(string year)
        {
            return musicDataList.Where(x => x.Time.Year.ToString() == year).Select(x => x.Artist).Distinct().Count();

            //List<Play> allArtistsAndPlaysOfTheYear = musicDataList.Where(x => x.Time.Year.ToString() == year).ToList();
            //List<string> justArtistNames = allArtistsAndPlaysOfTheYear.Select(x => x.Artist).ToList();
            //List<string> justUniqueArtistNames = justUniqueArtistNames.Distinct().ToList();
        }
        /// <summary>
        /// A function that returns a List of unique strings which contains
        /// the Title of each track by a specific artists
        /// </summary>
        /// <param name="artistName">artist</param>
        /// <returns>list of song titles</returns>
        public static List<string> TrackListByArtist(string artistName)
        {
            //1. get all Plays by artist
            List<Play> allPlaysByArtist = musicDataList.Where(x => x.Artist.ToLower() == artistName.ToLower()).ToList();
            //2. select all of the tracks
            List<string> allTracksByTheArtist = allPlaysByArtist.Select(x => x.Title).ToList();
            //3. return the unique (distinct) tracks
            List<string> allDistinctTracksByTheArtist = allTracksByTheArtist.Distinct().ToList();
            return allDistinctTracksByTheArtist;

            return musicDataList
                .Where(x => x.Artist.ToLower() == artistName.ToLower())
                .Select(x => x.Title)
                .Distinct()
                .ToList();
        }
        /// <summary>
        /// A function that returns the first time an artist was ever played
        /// </summary>
        /// <param name="artistName">artist name</param>
        /// <returns>DateTime of first play</returns>
        public static DateTime FirstPlayByArtist(string artistName)
        {
            //1. filter all plays based on the artist
            List<Play> playsByTheArtist = musicDataList.Where(x => x.Artist.ToLower() == artistName.ToLower()).ToList();
            //2. order the plays by date
            List<Play> playsByTheArtistOrderedByDate = playsByTheArtist.OrderBy(x => x.Time).ToList();
            //3. take the first play, return its datetime
            Play firstPlayEverByArtist = playsByTheArtistOrderedByDate.First();
            return firstPlayEverByArtist.Time;

            //one line pro solution
            return musicDataList.Where(x => x.Artist.ToLower() == artistName.ToLower()).OrderBy(x => x.Time).First().Time;
        }
        /// <summary>
        ///                     ***BONUS***
        /// A function that will determine the most played artist in a specified year
        /// </summary>
        /// <param name="year">year to check</param>
        /// <returns>most popular artist in year</returns>
        public static string MostPopularArtistByYear(string year)
        {
            //1. filter plays by the year
            List<Play> playsInTheYear = musicDataList.Where(x => x.Time.Year.ToString() == year).ToList();
            //2. group the plays by the artist
            List<IGrouping<string, Play>> playsGroupedByArtist = playsInTheYear.GroupBy(x => x.Artist).ToList();
            //3. order them in the descending based on the number of plays
            List<IGrouping<string, Play>> orderedPlaysGroupedByArtist = playsGroupedByArtist.OrderByDescending(x => x.Count()).ToList();
            //4. take the first item out
            IGrouping<string, Play> mostPopular = orderedPlaysGroupedByArtist.First();
            //5. return the artist name
            return mostPopular.Key;

            return musicDataList.Where(x => x.Time.Year.ToString() == year).GroupBy(x => x.Artist).OrderByDescending(x => x.Count()).First().Key;
        }
    }

    public class Play
    {
        // Properties
        public DateTime Time { get; set; }
        public string Artist { get; set; }
        public string Title { get; set; }
        public string Album { get; set; }
        public Play(string lineInput)
        {

            ///1138820121000	Bright Eyes	carrots/diamonds	Live At  Nightclub930 Washington DC 0129		78f797e3-4913-4026-aad0-1cd858bd735b	
            ///
            // Split using the tab character due to the tab delimited data format
            string[] playData = lineInput.Split('\t');

            // Get the time in milliseconds and convert to C# DateTime
            DateTime posixTime = DateTime.SpecifyKind(new DateTime(1970, 1, 1), DateTimeKind.Utc);
            this.Time = posixTime.AddMilliseconds(long.Parse(playData[0]));
            this.Artist = playData[1];
            this.Title = playData[2];
            this.Album = playData[3];
            // need to populate the rest of the properties

        }

        public Play(string artist, string album)
        {
            this.Artist = artist; this.Album = album;
        }
    }
}
