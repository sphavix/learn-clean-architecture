using Movies.Core.Entities.Base;

namespace Movies.Core.Repositories.Generic
{
    public interface IRepository<T> where T : Entity
    {
        Task<IReadOnlyList<T>> GetMoviesAsync();
        Task<T> GetMovieByIdAsync(int id);
        Task<T> AddMovieAsync(T entity);
        Task UpdateMovieAsync(T entity);
        Task DeleteMovieAsync(T entity);
    }
}