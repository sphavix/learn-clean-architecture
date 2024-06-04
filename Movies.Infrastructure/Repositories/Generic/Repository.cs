using Microsoft.EntityFrameworkCore;
using Movies.Core.Entities.Base;
using Movies.Core.Repositories.Generic;
using Movies.Infrastructure.Data;

namespace Movies.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        protected readonly MovieContext _context;
        public Repository(MovieContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IReadOnlyList<T>> GetMoviesAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetMovieByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<T> AddMovieAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync().ConfigureAwait(true);
            return entity;
        }

        public async Task UpdateMovieAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync().ConfigureAwait(true);
        }

        public async Task DeleteMovieAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync().ConfigureAwait(true);
        
        }
    }
}