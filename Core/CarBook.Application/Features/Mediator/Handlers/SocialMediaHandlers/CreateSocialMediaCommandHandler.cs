using AutoMapper;
using CarBook.Application.Features.Mediator.Commands.SocialMediaCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.SocialMediaHandlers
{
    public class CreateSocialMediaCommandHandler : IRequestHandler<CreateSocialMediaCommand>
    {
        private readonly IRepository<SocialMedia> _repository;
        private readonly IMapper _mapper;
        public CreateSocialMediaCommandHandler(IRepository<SocialMedia> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(CreateSocialMediaCommand request, CancellationToken cancellationToken)
        {
            var values = _mapper.Map<SocialMedia>(request);
            await _repository.CreateAsyc(values);

        }
    }
}
