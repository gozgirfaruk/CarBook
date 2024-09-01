using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Commands.CarCommands
{
    public class RemoveCarCommand : IRequest
    {
        public int  Id { get; set; }
        public RemoveCarCommand(int id)
        {
            Id = id;
        }
    }
}
