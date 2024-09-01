using AutoMapper;
using CarBook.Application.Features.Mediator.Queries.LocationQueries;
using CarBook.Application.Features.Mediator.Results.LocationResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.LocationHandlers
{
    public class GetByIdLocationQueryHandler : IRequestHandler<GetByIdLocationQuery, GetByIdLocationQueryResult>
    {
        private readonly IRepository<Location> _repository;
        private readonly IMapper _mapper;
        public GetByIdLocationQueryHandler(IRepository<Location> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetByIdLocationQueryResult> Handle(GetByIdLocationQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            return _mapper.Map<GetByIdLocationQueryResult>(values);
        }
    }
}
