using Microsoft.EntityFrameworkCore;
using Movies.Core.Entities;
using Movies.Core.Repositories;
using Movies.Infrastructure.Data;

namespace Movies.Infrastructure.Repositories
{
    public class MovieRepository : Repository<Movie>, IMovieRepository
    {
        public MovieRepository(MovieContext context): base(context)
        {
            
        }

        public async Task<IEnumerable<Movie>> GetMoviesByDirectorNameAsync(string directorName)
        {
            return await _context.Movies.Where(m => m.DirectorName == directorName).ToListAsync();
        }
        
    }
}