﻿using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.AboutCommands
{
    public class RemoveAboutCommand : IRequest
    {
        public int Id { get; set; }

        public RemoveAboutCommand(int id)
        {
            Id = id;
        }
    }
}
