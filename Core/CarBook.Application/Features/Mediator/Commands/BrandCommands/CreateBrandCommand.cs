﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Commands.BrandCommands
{
    public class CreateBrandCommand : IRequest
    {
        public string Name { get; set; }
        public string Logo { get; set; }
    }
}
