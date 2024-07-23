using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Movies.Application.Commands;
using Movies.Core.Entities;
using Movies.Core.Repositories;

namespace Movies.Application.Handlers
{
    public class UpdateMovieCommandHandler :IRequestHandler<UpdateMovieCommand, bool>
    {
        private readonly IMovieRepository _movieRepository;
        public UpdateMovieCommandHandler(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository ?? throw new ArgumentNullException(nameof(movieRepository));
        }

        public async Task<bool> Handle(UpdateMovieCommand command, CancellationToken cancellationToken)
        {
            var movie = await _movieRepository.UpdateMovieAsync(new Movie
            {
                Id = command.Id,
                Title = command.MovieName,
                ReleaseYear = command.ReleaseYear,
                DirectorName = command.DirectorName
            });

            return movie;
        }
    }
}