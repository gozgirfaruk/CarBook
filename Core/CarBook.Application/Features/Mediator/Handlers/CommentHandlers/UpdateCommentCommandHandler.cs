using AutoMapper;
using CarBook.Application.Features.Mediator.Commands.CommentCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.CommentHandlers
{
    public class UpdateCommentCommandHandler : IRequestHandler<UpdateCommentCommand>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Comment> _repository;
        public UpdateCommentCommandHandler(IMapper mapper, IRepository<Comment> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
        {
            var values = _mapper.Map<Comment>(request);
            await _repository.UpdateAsync(values);
        }
    }
}
