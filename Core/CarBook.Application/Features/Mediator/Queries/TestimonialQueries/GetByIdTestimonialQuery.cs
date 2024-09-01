using CarBook.Application.Features.Mediator.Results.TestimonialResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Queries.TestimonialQueries
{
    public class GetByIdTestimonialQuery : IRequest<GetByIdTestimonialQueryResult>
    {
        public int Id { get; set; }

        public GetByIdTestimonialQuery(int id)
        {
            Id = id;
        }
    }
}
