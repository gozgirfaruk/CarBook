using CarBook.Application.Features.Mediator.Results.ReviewResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Interfaces
{
	public interface IReviewListByCarIdRepository
	{
		Task<List<GetReviewListQueryResult>> GetReviewListByCarIdAsync(int id);
	}
}
