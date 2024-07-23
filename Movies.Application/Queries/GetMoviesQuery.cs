using MediatR;
using Movies.Application.Responses;

namespace Movies.Application.Queries
{
    public class GetMoviesQuery : IRequest<IList<MovieResponse>>
    {
        
    }
}