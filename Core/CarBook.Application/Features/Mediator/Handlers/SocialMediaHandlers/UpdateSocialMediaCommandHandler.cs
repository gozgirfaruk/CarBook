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
    public class UpdateSocialMediaCommandHandler : IRequestHandler<UpdateSocialMediaCommand>
    {
        private readonly IRepository<SocialMedia> _repository;
        private readonly IMapper _mapper;

        public UpdateSocialMediaCommandHandler(IRepository<SocialMedia> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(UpdateSocialMediaCommand request, CancellationToken cancellationToken)
        {
            var values = _mapper.Map<SocialMedia>(request);
            await _repository.UpdateAsync(values);
        }
    }
}
