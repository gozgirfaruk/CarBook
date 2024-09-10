using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Dtos.BrandDtos
{
   public class UpdateBrandDto
    {
        public int brandId { get; set; }
        public string name { get; set; }
        public string logo { get; set; }
    }
}
