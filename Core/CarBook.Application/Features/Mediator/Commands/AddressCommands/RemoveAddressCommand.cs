using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Commands.AddressCommands
{
    public class RemoveAddressCommand : IRequest
    {
        public int Id { get; set; }

        public RemoveAddressCommand(int id)
        {
            Id = id;
        }
    }
}
