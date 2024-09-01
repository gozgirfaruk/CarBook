using CarBook.Application.Features.Mediator.Results.LocationResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Queries.LocationQueries
{
    public class GetByIdLocationQuery : IRequest<GetByIdLocationQueryResult>
    {
        public int Id { get; set; }

        public GetByIdLocationQuery(int id)
        {
            Id = id;
        }
    }
}
