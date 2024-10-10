using CarBook.Application.Features.Mediator.Queries.CarPricingQueries;
using CarBook.Application.Features.Mediator.Results.CarPricingResults;
using CarBook.Application.Interfaces;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.CarPricingHandlers
{
	public class GetCarPricingWithPivotQueryHandler : IRequestHandler<GetCarPricingsWithPivotQuery, List<GetCarPricingWithPivotQueryResult>>
	{
		private readonly ICarRepository _carRepository;

		public GetCarPricingWithPivotQueryHandler( ICarRepository carRepository)
		{
			_carRepository = carRepository;
		}

		public async Task<List<GetCarPricingWithPivotQueryResult>> Handle(GetCarPricingsWithPivotQuery request, CancellationToken cancellationToken)
		{
			var values = _carRepository.GetCarWithPivot();
			return values.Select(x => new GetCarPricingWithPivotQueryResult
			{
				Brand = x.Brand,
				Model = x.Model,
				CoverImageUrl = x.CoverImageUrl,
				Daily = x.Amounts[0],
				Weekly = x.Amounts[1],
				Monthly = x.Amounts[2]
			}).ToList();
		}
	}
}
