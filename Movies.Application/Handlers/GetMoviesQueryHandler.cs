using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Movies.Application.Mappers;
using Movies.Application.Queries;
using Movies.Application.Responses;
using Movies.Core.Repositories;

namespace Movies.Application.Handlers
{
    public class GetMoviesQueryHandler : IRequestHandler<GetMoviesQuery, IList<MovieResponse>>
    {
        private readonly IMovieRepository _movieRepository;

        public GetMoviesQueryHandler(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository ?? throw new ArgumentNullException(nameof(movieRepository));
        }

        public async Task<IList<MovieResponse>> Handle(GetMoviesQuery query, CancellationToken cancellationToken)
        {
            var movies = await _movieRepository.GetMoviesAsync();
            var response = MovieMapper.Mapper.Map<IList<MovieResponse>>(movies);
            return response;
        }
    }
}