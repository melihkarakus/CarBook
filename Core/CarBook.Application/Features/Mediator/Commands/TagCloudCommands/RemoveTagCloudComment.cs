using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Commands.TagCloudCommands
{
    public class RemoveTagCloudComment : IRequest
    {
        public int Id { get; set; }

        public RemoveTagCloudComment(int id)
        {
            Id = id;
        }
    }
}
