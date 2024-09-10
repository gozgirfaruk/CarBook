using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Commands.BrandCommands
{
    public class UpdateBrandCommand : IRequest
    {
        public int BrandId { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }
    }
}
