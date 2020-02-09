using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Learning.Threads.BusinessRules
{
    public class MovieRules
    {
        private IQueryable<Movie> _movies;

        public MovieRules()
        {
            _movies = JsonConvert.DeserializeObject<List<Movie>>(File.ReadAllText("./Threads/Data/movies.json")).AsQueryable();
        }

        public MovieRules(IQueryable<Movie> movies)
        {
            _movies = movies;
        }

        /// <summary>
        /// Filter movies with more than a thousand IMDB votes, production budget greater than $120.000 and order by IMDB ratting from highest to lowest
        /// </summary>
        public void Easy()
        {
            Stopwatch s = new Stopwatch();
            s.Start();

            var result = (
                from movie in _movies
                where movie.IMDB_Votes > 1000 && movie.Production_Budget > 120_000
                orderby movie.IMDB_Rating descending
                select movie
            ).ToList();

            s.Stop();

            Console.WriteLine($"Easy: {s.ElapsedMilliseconds} - Quantity: {result.Count}");
        }

        /// <summary>
        /// Group movies by distributor and select the distributor, title, ratting and buget from the highest IMDB ratting movie 
        /// and show the data ordered by IMDB rating and if anyone has the same rate with other else, then order by budget
        /// </summary>
        public void Medium()
        {
            Stopwatch s = new Stopwatch();
            s.Start();

            var result = (
                from movie in _movies
                group movie by movie.Distributor into groupedMovies
                from highestRatingMovie in groupedMovies.Where(x => x.IMDB_Rating == groupedMovies.Max(y => y.IMDB_Rating))
                orderby highestRatingMovie.IMDB_Rating descending, highestRatingMovie.Production_Budget descending
                select new
                {
                    highestRatingMovie.Title,
                    highestRatingMovie.Distributor,
                    highestRatingMovie.IMDB_Rating,
                    highestRatingMovie.Production_Budget
                }

            )
            .ToList();

            s.Stop();

            Console.WriteLine($"Medium: {s.ElapsedMilliseconds} - Quantity: {result.Count}");
            result.ForEach(x => Console.WriteLine($"Medium: Title: {x.Title} - Distributor:{x.Distributor} - Rating:{x.IMDB_Rating} - Budget:{ x.Production_Budget}"));
        }
    }

    public class Movie
    {

        public Guid Id { get; set; }

        public String Title { get; set; }

        public long? US_Gross { get; set; }

        public long? Worldwide_Gross { get; set; }

        public String US_DVD_Sales { get; set; }

        public long? Production_Budget { get; set; }

        public DateTime Release_Date { get; set; } //

        public String MPAA_Rating { get; set; }

        public long? Running_Time_min { get; set; }

        public String Distributor { get; set; }

        public String Major_Genre { get; set; }

        public String Creative_Type { get; set; }

        public String Director { get; set; }

        public int? Rotten_Tomatoes_Rating { get; set; }

        public float? IMDB_Rating { get; set; }

        public int? IMDB_Votes { get; set; }







    }
}
