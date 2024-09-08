using AutoMapper;
using CarBook.Application.Features.Mediator.Queries.CarQueries;
using CarBook.Application.Features.Mediator.Results.CarResults;
using CarBook.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.CarHandlers
{
    public class GetCarWithPricingQueryHandler : IRequestHandler<GetCarWithPricingQuery, List<GetCarWithPricingQueryResult>>
    {
        private readonly ICarRepository _carRepository;
        private readonly IMapper _mapper;
        public GetCarWithPricingQueryHandler(ICarRepository carRepository, IMapper mapper)
        {
            _carRepository = carRepository;
            _mapper = mapper;
        }

        public async Task<List<GetCarWithPricingQueryResult>> Handle(GetCarWithPricingQuery request, CancellationToken cancellationToken)
        {
            var values = await _carRepository.GetCarWithPricings();
           return _mapper.Map<List<GetCarWithPricingQueryResult>>(values);
        }
    }
}
