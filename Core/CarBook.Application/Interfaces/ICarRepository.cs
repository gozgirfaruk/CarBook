using CarBook.Application.Features.Mediator.Results.CarResults;
using CarBook.Application.ViewModels;

namespace CarBook.Application.Interfaces
{
	public interface ICarRepository
    {
        Task<List<GetCarWithBrandQueryResult>> GetCarWithBrand();
        Task<List<GetCarWithPricingQueryResult>> GetCarWithPricings();
        List<CarPricingViewModel> GetCarWithPivot();
    }
}
