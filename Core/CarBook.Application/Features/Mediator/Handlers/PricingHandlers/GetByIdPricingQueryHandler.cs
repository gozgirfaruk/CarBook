using AutoMapper;
using CarBook.Application.Features.Mediator.Queries.PricingQueries;
using CarBook.Application.Features.Mediator.Results.PricingResults;
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
    public class GetByIdPricingQueryHandler : IRequestHandler<GetByIdPricingQuery, GetByIdPricingQueryResult>
    {
        private readonly IRepository<Pricing> _repository;
        private readonly IMapper _mapper;
        public GetByIdPricingQueryHandler(IRepository<Pricing> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetByIdPricingQueryResult> Handle(GetByIdPricingQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            return _mapper.Map<GetByIdPricingQueryResult>(values);
        }
    }
}
