using AutoMapper;
using CarBook.Application.Features.Mediator.Commands.AboutCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.TestimonialHandlers
{
    public class CreateAboutCommandHandler : IRequestHandler<CreateAboutCommand>
    {
        private readonly IRepository<About> _repository;
        private readonly IMapper _mapper;
        public CreateAboutCommandHandler(IRepository<About> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(CreateAboutCommand request, CancellationToken cancellationToken)
        {
            var values = _mapper.Map<About>(request);
            await _repository.CreateAsyc(values);

        }
    }
}
