using AutoMapper;
using CarBook.Application.Features.Mediator.Commands.PricingCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.PricingHandlers
{
    public class CreatePricingCommandHandler : IRequestHandler<CreatePricingCommand>
    {
        private readonly IRepository<Pricing> _repository;
        private readonly IMapper _mapper;
        public CreatePricingCommandHandler(IRepository<Pricing> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(CreatePricingCommand request, CancellationToken cancellationToken)
        {
            var values = _mapper.Map<Pricing>(request);
            await _repository.CreateAsyc(values);

        }
    }
}
