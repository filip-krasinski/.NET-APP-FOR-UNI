using Humanizer;
using Newtonsoft.Json;
using WebApplication6.Models;

namespace WebApplication10.Data
{
    public class DataSeeder
    {
        public static void Seed(ApplicationDbContext context)
        {
            //// your custom logic to generate random password 
            //// set it to right user
            if (context.Movies.Any())
            {
                return;
            }

            var cinemaHalls = SeedCinemaHalls();
            context.CinemaHalls.AddRange(cinemaHalls);

            var movies = SeedMovies();
            
            movies.ForEach(movie =>
            {
                movie.Poster = File.ReadAllBytes($"resources/{movie.Title.ToLower()}.jpg");
                movie.Screenings = GenerateScreenings(movie, cinemaHalls, 5, 14);
            });
            
            context.Movies.AddRange(movies); 
            context.SaveChanges();
        }

        public static IEnumerable<Screening> GenerateScreenings(
            Movie movie, 
            List<CinemaHall> cinemaHalls, 
            int maxPerDay, 
            int daysAfterToday
        )
        {
            var rnd = new Random();
            var currentDay = DateTime.Now.AtMidnight();
            var screenings = new List<Screening>();
            for (var i = 0; i < daysAfterToday; ++i)
            {
                var amountOfScreenings = rnd.Next(1, maxPerDay);
                for (var j = 0; j < amountOfScreenings; ++j)
                {
                    var minutes = new[] { 0, 15, 30, 45 };
                    var screeningDate = currentDay
                        .AddHours(rnd.Next(8, 23))
                        .AddMinutes(minutes[rnd.Next(minutes.Length)]);
                    
                    screenings.Add(new Screening
                    {
                        CinemaHall = cinemaHalls[rnd.Next(cinemaHalls.Count)],
                        ScreeningDate = screeningDate,
                        Movie = movie
                    });
                }

                currentDay = currentDay.AddDays(1);
            }

            return screenings;
        }
        
        public static List<CinemaHall> SeedCinemaHalls()
        {
            using var r = new StreamReader(@"resources/cinemahalls.json");
            return JsonConvert.DeserializeObject<List<CinemaHall>>(r.ReadToEnd());
        }
        
        public static List<Movie> SeedMovies()
        {
            using var r = new StreamReader(@"resources/Movies.json");
            return JsonConvert.DeserializeObject<List<Movie>>(r.ReadToEnd());
        }
    }
}