using CarBook.Application.Features.Mediator.Queries.ReviewQueries;
using CarBook.Application.Features.Mediator.Results.ReviewResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.ReviewHandlers
{
	public class GetReviewListQueryHandler : IRequestHandler<GetReviewListQuery, List<GetReviewListQueryResult>>
	{
		private readonly IReviewListByCarIdRepository _repository;

		public GetReviewListQueryHandler(IReviewListByCarIdRepository repository)
		{
			_repository = repository;
		}

		public async Task<List<GetReviewListQueryResult>> Handle(GetReviewListQuery request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetReviewListByCarIdAsync(request.Id);
			return values;
		}
	}
}
