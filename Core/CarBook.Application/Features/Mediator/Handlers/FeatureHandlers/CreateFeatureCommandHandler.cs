using AutoMapper;
using CarBook.Application.Features.Mediator.Commands.FeatureCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.FeatureHandlers
{
    public class CreateFeatureCommandHandler : IRequestHandler<CreateFeatureCommand>
    {
        private readonly IRepository<Feature> _repository;
        private readonly IMapper _mapper;
        public CreateFeatureCommandHandler(IRepository<Feature> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(CreateFeatureCommand request, CancellationToken cancellationToken)
        {
            var values = _mapper.Map<Feature>(request);
            await _repository.CreateAsyc(values);

        }
    }
}
