using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Results.CarPricingResults
{
	public class GetCarPricingWithPivotQueryResult
	{
        public string Model { get; set; }
        public string Brand { get; set; }
        public string CoverImageUrl { get; set; }
        public decimal Daily { get; set; }
        public decimal Weekly { get; set; }
        public decimal Monthly { get; set; }
    }
}
