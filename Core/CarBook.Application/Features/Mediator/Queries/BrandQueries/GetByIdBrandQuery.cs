using CarBook.Application.Features.Mediator.Results.BrandResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Queries.BrandQueries
{
    public class GetByIdBrandQuery : IRequest<GetByIdBrandQueryResult>
    {
        public int Id { get; set; }

        public GetByIdBrandQuery(int id)
        {
            Id = id;
        }
    }
}
