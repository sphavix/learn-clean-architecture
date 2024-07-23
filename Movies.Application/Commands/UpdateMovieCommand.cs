using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Movies.Application.Commands
{
    public class UpdateMovieCommand : IRequest<bool>
    {
         public Guid Id { get; set; }   
        public string MovieName { get; set; }
        public string DirectorName { get; set; }
        public string ReleaseYear { get; set; }
    }
}