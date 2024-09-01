using AutoMapper;
using CarBook.Application.Features.Mediator.Queries.ServiceQueries;
using CarBook.Application.Features.Mediator.Results.ServiceResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.ServiceHandlers
{
    public class GetByIdServiceQueryHandler : IRequestHandler<GetByIdServiceQuery, GetByIdServiceQueryResult>
    {
        private readonly IRepository<Service> _repository;
        private readonly IMapper _mapper;
        public GetByIdServiceQueryHandler(IRepository<Service> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetByIdServiceQueryResult> Handle(GetByIdServiceQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            return _mapper.Map<GetByIdServiceQueryResult>(values);
        }
    }
}
