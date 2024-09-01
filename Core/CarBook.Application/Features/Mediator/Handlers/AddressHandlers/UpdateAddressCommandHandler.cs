using AutoMapper;
using CarBook.Application.Features.Mediator.Commands.AddressCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.AddressHandlers
{
    public class UpdateAddressCommandHandler : IRequestHandler<UpdateAddressCommand>
    {
        private readonly IRepository<FooterAdress> _repository;
        private readonly IMapper _mapper;

        public UpdateAddressCommandHandler(IRepository<FooterAdress> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(UpdateAddressCommand request, CancellationToken cancellationToken)
        {
            var values = _mapper.Map<FooterAdress>(request);    
            await _repository.UpdateAsync(values);
        }
    }
}
