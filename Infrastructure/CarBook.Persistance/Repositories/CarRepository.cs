using AutoMapper;
using CarBook.Application.Features.Mediator.Results.CarResults;
using CarBook.Application.Interfaces;
using CarBook.Application.ViewModels;
using CarBook.Persistance.Context;
using Microsoft.EntityFrameworkCore;

namespace CarBook.Persistance.Repositories
{
	public class CarRepository : ICarRepository
	{
		private readonly CarbookContext _context;
		private readonly IMapper _mapper;

		public CarRepository(CarbookContext context, IMapper mapper, string connectionString)
		{
			_context = context;
			_mapper = mapper;
		}

		public async Task<List<GetCarWithBrandQueryResult>> GetCarWithBrand()
		{
			var values = await _context.Cars.Include(x => x.Brand).ToListAsync();
			return _mapper.Map<List<GetCarWithBrandQueryResult>>(values);
		}

		public List<CarPricingViewModel> GetCarWithPivot()
		{
			List<CarPricingViewModel> values = new List<CarPricingViewModel>();
			using (var command = _context.Database.GetDbConnection().CreateCommand())
			{
				command.CommandText = "Select * From (Select Brands.Name,CoverImageUrl,Model,PricingId,Amount From CarPricings Inner Join Cars On CarPricings.CarId=Cars.CarId Inner Join Brands On Cars.BrandId=Brands.BrandId) As SourceTable Pivot(Sum(Amount) For PricingId In ([1],[2],[3])) as PivotTable;";
				command.CommandType = System.Data.CommandType.Text;
				_context.Database.OpenConnection();
				using (var reader = command.ExecuteReader())
				{
					while (reader.Read())
					{
						CarPricingViewModel carPricingViewModel = new CarPricingViewModel()
						{
							Brand = reader["Name"].ToString(),
							Model = reader["Model"].ToString(),
							CoverImageUrl = reader["CoverImageUrl"].ToString(),
							Amounts = new List<decimal>
							{
								Convert.ToDecimal(reader["1"]),
								Convert.ToDecimal(reader["2"]),
								Convert.ToDecimal(reader["3"])
							}
						};
						values.Add(carPricingViewModel);
					}
				}
				_context.Database.CloseConnection();
				return values;
			}
		} 

		public async Task<List<GetCarWithPricingQueryResult>> GetCarWithPricings()
        {
            var values = await _context.CarPricings.Include(x=>x.Car).ThenInclude(y=>y.Brand).Include(x=>x.Pricing).ToListAsync();
            return _mapper.Map<List<GetCarWithPricingQueryResult>>(values);
        }
    }
}
