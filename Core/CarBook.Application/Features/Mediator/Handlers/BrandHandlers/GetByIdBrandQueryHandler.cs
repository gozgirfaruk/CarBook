using AutoMapper;
using CarBook.Application.Features.Mediator.Queries.BrandQueries;
using CarBook.Application.Features.Mediator.Results.BrandResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.BrandHandlers
{
    public class GetByIdBrandQueryHandler : IRequestHandler<GetByIdBrandQuery, GetByIdBrandQueryResult>
    {
        private readonly IRepository<Brand> _repository;
        private readonly IMapper _mapper;

        public GetByIdBrandQueryHandler(IMapper mapper, IRepository<Brand> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<GetByIdBrandQueryResult> Handle(GetByIdBrandQuery request, CancellationToken cancellationToken)
        {
           var values = await _repository.GetByIdAsync(request.Id);
            return _mapper.Map<GetByIdBrandQueryResult>(values);
        }
    }
}
