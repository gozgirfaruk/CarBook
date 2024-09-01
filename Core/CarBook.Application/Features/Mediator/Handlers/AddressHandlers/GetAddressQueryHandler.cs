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
    public class GetAddressQueryHandler : IRequestHandler<GetAddressQuery, List<GetAddressQueryResult>>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<FooterAdress> _repository;

        public GetAddressQueryHandler(IRepository<FooterAdress> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetAddressQueryResult>> Handle(GetAddressQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return _mapper.Map<List<GetAddressQueryResult>>(values);
        }
    }
}
