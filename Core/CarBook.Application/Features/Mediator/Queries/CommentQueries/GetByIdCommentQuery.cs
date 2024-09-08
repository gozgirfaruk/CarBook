using CarBook.Application.Features.Mediator.Results.CommentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Queries.CommentQueries
{
    public class GetByIdCommentQuery : IRequest<GetByIdCommentQueryResult>
    {
        public int Id { get; set; }
        public GetByIdCommentQuery(int id)
        {
            Id= id;
        }
    }

}
