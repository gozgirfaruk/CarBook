using CarBook.Application.Features.Mediator.Results.BannerResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Queries.BannerQueries
{
    public class GetByıdBannerQuery : IRequest<GetByIdBannerQueryResult>
    {
        public int Id { get; set; }

        public GetByıdBannerQuery(int id)
        {
            Id = id;
        }
    }
}
