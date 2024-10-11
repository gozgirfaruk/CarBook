using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Dtos.CarPricingDtos
{
	public class ResultCarPricingListWithModelDto
	{
		public string model { get; set; }
		public string dailyAmount { get; set; }
		public string weeklyAmount { get; set; }
		public string monthlyAmount { get; set; }
		public string coverImageUrl { get; set; }
        public string brand { get; set; }
    }
}
