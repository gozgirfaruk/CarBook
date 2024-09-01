using AutoMapper;
using CarBook.Application.Features.Mediator.Queries.AddressQueries;
using CarBook.Application.Features.Mediator.Results.AddressResults;
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
    public class GetByIdAddressQueryHandler : IRequestHandler<GetByIdAddressQuery, GetByIdAddressQueryResult>
    {
        private readonly IRepository<FooterAdress> _repository;
        private readonly IMapper _mapper;

        public GetByIdAddressQueryHandler(IRepository<FooterAdress> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetByIdAddressQueryResult> Handle(GetByIdAddressQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            return _mapper.Map<GetByIdAddressQueryResult>(values);
        }
    }
}
