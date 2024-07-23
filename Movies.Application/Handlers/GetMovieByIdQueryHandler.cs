using MediatR;
using Movies.Application.Mappers;
using Movies.Application.Queries;
using Movies.Application.Responses;
using Movies.Core.Repositories;

namespace Movies.Application.Handlers
{
    public class GetMovieByIdQueryHandler : IRequestHandler<GetMovieByIdQuery, MovieResponse>
    {
        private readonly IMovieRepository _movieRepository;
        public GetMovieByIdQueryHandler(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository ?? throw new ArgumentNullException(nameof(movieRepository));
        }

        public async Task<MovieResponse> Handle(GetMovieByIdQuery query, CancellationToken cancellationToken)
        {
            var movie = await _movieRepository.GetMovieByIdAsync(query.Id);
            var response = MovieMapper.Mapper.Map<MovieResponse>(movie);
            return response;
        }
    }
}