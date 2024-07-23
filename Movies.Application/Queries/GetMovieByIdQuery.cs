using MediatR;
using Movies.Application.Responses;

namespace Movies.Application.Queries
{
    public class GetMovieByIdQuery : IRequest<MovieResponse>
    {
        public Guid Id { get; set; }

        public GetMovieByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}