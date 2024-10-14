using AutoMapper;
using CarBook.Application.Features.Mediator.Results.ReviewResults;
using CarBook.Application.Interfaces;
using CarBook.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistance.Repositories
{
	public class GetReviewListByCarIdRepository : IReviewListByCarIdRepository
	{
		private readonly CarbookContext _context;
		private readonly IMapper _mapper;
		public GetReviewListByCarIdRepository(CarbookContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public async Task<List<GetReviewListQueryResult>> GetReviewListByCarIdAsync(int id)
		{
			var values = await _context.Reviews.Where(x => x.CarId == id).ToListAsync();
			return _mapper.Map<List<GetReviewListQueryResult>>(values);
		}
	}
}
