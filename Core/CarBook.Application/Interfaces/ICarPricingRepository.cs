using CarBook.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Interfaces
{
	public interface ICarPricingRepository
	{
		List<CarPricingViewModel> GetCarPricingWithTimePeriod1();
	}
}
