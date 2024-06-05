using AutoMapper;
using MediatR;
using Movies.Application.Commands;
using Movies.Application.Mappers;
using Movies.Application.Responses;
using Movies.Core.Entities;
using Movies.Core.Repositories;

namespace Movies.Application.Handlers
{
    public class CreateMovieCommandHandler: IRequestHandler<CreateMovieCommand, MovieResponse>
    {
        private readonly IMovieRepository _movieRepository;

        public CreateMovieCommandHandler(IMovieRepository repository)
        {
            _movieRepository = repository;
        }

        public async Task<MovieResponse> Handle(CreateMovieCommand request, CancellationToken cancellationToken)
        {
            var movie = MovieMapper.Mapper.Map<Movie>(request);
            if(movie is null)
            {
                throw new ApplicationException("There was an error in mapper");
            }

            var newMovie = await _movieRepository.AddMovieAsync(movie);
            var response = MovieMapper.Mapper.Map<MovieResponse>(newMovie);
            return response;
        }
    }
}