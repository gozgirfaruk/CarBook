using AutoMapper;
using CarBook.Application.Features.Mediator.Commands.ServiceCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.ServiceHandlers
{
    public class CreateServiceCommandHandler : IRequestHandler<CreateServiceCommand>
    {
        private readonly IRepository<Service> _repository;
        private readonly IMapper _mapper;
        public CreateServiceCommandHandler(IRepository<Service> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(CreateServiceCommand request, CancellationToken cancellationToken)
        {
            var values = _mapper.Map<Service>(request);
            await _repository.CreateAsyc(values);

        }
    }
}
