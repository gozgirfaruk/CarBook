using CarBook.Application.Features.Mediator.Results.SocialMediaResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Queries.SocialMediaQueries
{
    public class GetByıdSocialMediaQuery : IRequest<GetByIdSocialMediaQueryResult>
    {
        public int Id { get; set; }

        public GetByıdSocialMediaQuery(int id)
        {
            Id = id;
        }
    }
}
