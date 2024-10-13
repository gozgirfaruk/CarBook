using CarBook.Application.Features.Mediator.Results.CarResults;

namespace CarBook.Application.Interfaces
{
	public interface ICarRepository
    {
        Task<List<GetCarWithBrandQueryResult>> GetCarWithBrand();
        Task<List<GetCarWithPricingQueryResult>> GetCarWithPricings();
        Task<GetCarWithBrandQueryResult> GetCarWithBrandByCarId(int id);
    }
}
