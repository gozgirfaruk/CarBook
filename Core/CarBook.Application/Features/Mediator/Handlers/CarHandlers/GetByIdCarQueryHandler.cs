using AutoMapper;
using CarBook.Application.Features.Mediator.Queries.CarQueries;
using CarBook.Application.Features.Mediator.Results.CarResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.CarHandlers
{
    public class GetByIdCarQueryHandler : IRequestHandler<GetByIdCarQuery, GetByIdCarQueryResult>
    {
        private readonly IRepository<Car> _repository;
        private readonly IMapper _mapper;

        public GetByIdCarQueryHandler(IMapper mapper, IRepository<Car> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<GetByIdCarQueryResult> Handle(GetByIdCarQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            return _mapper.Map<GetByIdCarQueryResult>(values);
        }
    }
}
