using Microsoft.EntityFrameworkCore;
using WebApplication10.Data;
using WebApplication6.Models;

namespace WebApplication10.Repositories
{
    public class MovieRepository
    {
        private readonly ApplicationDbContext _context;

        public MovieRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public async Task<List<Movie>> GetMovies(DateTime date)
        {
            return await _context.Movies
                .Include(m => 
                    m.Screenings.Where(s => s.ScreeningDate.Date == date.Date)
                )
                .ToListAsync();
        }
        
        public List<Movie> GetMoviesSync()
        {
            return _context.Movies.ToList();
        }
    }
}