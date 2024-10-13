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
	public class GetCarWithBrandByCarIdQueryHandler : IRequestHandler<GetCarWithBrandByCarIdQuery, GetCarWithBrandQueryResult>
	{
		private readonly ICarRepository _repository;

		public GetCarWithBrandByCarIdQueryHandler(ICarRepository repository)
		{
			_repository = repository;
		}

		public async Task<GetCarWithBrandQueryResult> Handle(GetCarWithBrandByCarIdQuery request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetCarWithBrandByCarId(request.Id);
			return values;
		}
	}
}
