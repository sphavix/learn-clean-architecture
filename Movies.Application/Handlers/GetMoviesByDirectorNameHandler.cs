using MediatR;
using Movies.Application.Mappers;
using Movies.Application.Queries;
using Movies.Application.Responses;
using Movies.Core.Repositories;

namespace Movies.Application.Handlers
{
    public class GetMoviesByDirectorNameHandler: IRequestHandler<GetMoviesByDirectorNameQuery, IEnumerable<MovieResponse>>
    {
        private readonly IMovieRepository _movieRepository;

        public GetMoviesByDirectorNameHandler(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<IEnumerable<MovieResponse>> Handle(GetMoviesByDirectorNameQuery request, CancellationToken cancellationToken)
        {
            var movies = await _movieRepository.GetMoviesByDirectorNameAsync(request.DirectorName);
            var response = MovieMapper.Mapper.Map<IEnumerable<MovieResponse>>(movies);
            return response;
        }
    
    }
}