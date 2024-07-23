using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Movies.Application.Commands
{
    public class DeleteMovieCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
       
    }
}