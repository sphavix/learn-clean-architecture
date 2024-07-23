using MediatR;
using Movies.Application.Commands;
using Movies.Core.Repositories;

namespace Movies.Application.Handlers
{
    public class DeleteMovieCommandHandler : IRequestHandler<DeleteMovieCommand, bool>
    {
        private readonly IMovieRepository _movieRepository;

        public DeleteMovieCommandHandler(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository ?? throw new ArgumentNullException(nameof(movieRepository));
        }

        public async Task<bool> Handle(DeleteMovieCommand command, CancellationToken cancellationToken)
        {
            var movie = await _movieRepository.GetMovieByIdAsync(command.Id);
            if (movie == null)
            {
                return default;
            }

            await _movieRepository.DeleteMovieAsync(movie.Id);
            return true;
            
        }
    }
}