using AutoMapper;
using CarBook.Application.Features.Mediator.Commands.BannerCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.BannerHandlers
{
    public class CreateBannerCommandHandler : IRequestHandler<CreateeBannerCommand>
    {
        private readonly IRepository<Banner> _repository;
        private readonly IMapper _mapper;
        public CreateBannerCommandHandler(IRepository<Banner> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(CreateeBannerCommand request, CancellationToken cancellationToken)
        {
            var values = _mapper.Map<Banner>(request);
            await _repository.CreateAsyc(values);

        }
    }
}
