using AutoMapper;
using CarBook.Application.Features.Mediator.Queries.RentACarQueries;
using CarBook.Application.Features.Mediator.Results.RentACarResults;
using CarBook.Application.Interfaces;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.RentACarHandlers
{
    public class GetRentACarQueryHandler : IRequestHandler<GetRentACarQuery, List<GetRentACarQueryResult>>
    {
        private readonly IMapper _mapper;
        private readonly IRentACarRepository _repository;
        public GetRentACarQueryHandler(IMapper mapper, IRentACarRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<List<GetRentACarQueryResult>> Handle(GetRentACarQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByFilterAsync(x => x.LocationId == request.LocationId && x.Available == true);
            var result = values.Select(x => new GetRentACarQueryResult
            {
                RentACarId = x.RentACarId,
                Brand=x.Car.Brand.Name,
                Model=x.Car.Model,
                CoverImageUrl=x.Car.CoverImageUrl
            }).ToList();
            return result;
        }
    }
}
