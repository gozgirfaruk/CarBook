using CarBook.Application.Features.Mediator.Results.PricingResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Queries.PricingQueries
{
    public class GetByIdPricingQuery : IRequest<GetByIdPricingQueryResult>
    {
        public int Id { get; set; }

        public GetByIdPricingQuery(int id)
        {
            Id = id;
        }
    }
}
