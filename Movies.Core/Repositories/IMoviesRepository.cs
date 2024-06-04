using Movies.Core.Entities;
using Movies.Core.Repositories.Generic;

namespace Movies.Core.Repositories
{
    public interface IMovieRepository : IRepository<Movie>
    {
        Task<IEnumerable<Movie>> GetMoviesByDirectorNameAsync(string directorName);
    }
}