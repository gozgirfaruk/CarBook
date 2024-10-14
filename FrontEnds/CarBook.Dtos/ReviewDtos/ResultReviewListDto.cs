using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Dtos.ReviewDtos
{
	public class ResultReviewListDto
	{
		public int ReviewId { get; set; }
		public string CustomerName { get; set; }
		public string CustomerImage { get; set; }
		public string Content { get; set; }
		public string RatingValue { get; set; }
		public DateTime ReviewDate { get; set; }
		public int CarId { get; set; }
	}
}
