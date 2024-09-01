using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Results.LocationResults
{
    public class GetByIdLocationQueryResult
    {
        public int LocationId { get; set; }
        public string LocationName { get; set; }
    }
}
