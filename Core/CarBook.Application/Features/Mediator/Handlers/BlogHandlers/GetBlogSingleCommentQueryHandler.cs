using AutoMapper;
using CarBook.Application.Features.Mediator.Queries.BlogQueries;
using CarBook.Application.Features.Mediator.Results.BlogResults;
using CarBook.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.BlogHandlers
{
    public class GetBlogSingleCommentQueryHandler : IRequestHandler<GetBlogSingleCommentQuery, List<GetBlogSingleCommentQueryResult>>
    {
        private readonly IBlogRepository _repository;
        private readonly IMapper _mapper;

        public GetBlogSingleCommentQueryHandler(IBlogRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetBlogSingleCommentQueryResult>> Handle(GetBlogSingleCommentQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetBlogSingleComment(request.Id);
            return _mapper.Map<List<GetBlogSingleCommentQueryResult>>(values);
        }
    }
}
