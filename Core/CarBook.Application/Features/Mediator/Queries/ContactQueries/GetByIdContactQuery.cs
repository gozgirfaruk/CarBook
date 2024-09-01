using CarBook.Application.Features.Mediator.Results.ContactResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Queries.ContactQueries
{
    public class GetByIdContactQuery : IRequest<GetByIdContactQueryResult>
    {
        public  int  Id { get; set; }

        public GetByIdContactQuery(int id)
        {
            Id = id;
        }
    }
}
