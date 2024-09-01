using CarBook.Application.Features.Mediator.Results.AddressResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Queries.AddressQueries
{
    public class GetByIdAddressQuery : IRequest<GetByIdAddressQueryResult>
    {
        public int Id { get; set; }

        public GetByIdAddressQuery(int id)
        {
            Id = id;
        }
    }
}
