using Microsoft.EntityFrameworkCore;
using Movies.Core.Entities;
using Movies.Core.Repositories;
using Movies.Infrastructure.Data;

namespace Movies.Infrastructure.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly MovieContext _context;
        public MovieRepository(MovieContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Movie>> GetMoviesAsync()
        {
            return await _context.Movies.ToListAsync();
        }
        public async Task<Movie> GetMovieByIdAsync(Guid id)
        {
            return await _context.Movies.Where(x => x.Id == id).FirstOrDefaultAsync().ConfigureAwait(true);
        }
        public async Task<Movie> AddMovieAsync(Movie movie)
        {
            var result = _context.Movies.Add(movie);
            await _context.SaveChangesAsync().ConfigureAwait(true);
            return result.Entity;
        }
        public async Task<bool> UpdateMovieAsync(Movie movie)
        {
            _context.Movies.Update(movie);
            return await _context.SaveChangesAsync().ConfigureAwait(true) > 0;
        }
        public async Task<bool> DeleteMovieAsync(Guid id)
        {
            var movie = await _context.Movies.FindAsync(id).ConfigureAwait(true);
            _context.Movies.Remove(movie);
            return await _context.SaveChangesAsync().ConfigureAwait(true) > 0;
        }
        
    }
}