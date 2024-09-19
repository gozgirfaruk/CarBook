using AutoMapper;
using CarBook.Application.Features.Mediator.Queries.CommentQueries;
using CarBook.Application.Features.Mediator.Results.CommentResults;
using CarBook.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.CommentHandlers
{
    public class GetCommentWithBlogQueryHandler : IRequestHandler<GetCommentWithBlogQuery, List<GetCommentWithBlogQueryResult>>
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;
        public GetCommentWithBlogQueryHandler(ICommentRepository commentRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }

       
        public async Task<List<GetCommentWithBlogQueryResult>> Handle(GetCommentWithBlogQuery request, CancellationToken cancellationToken)
        {
            var values = await _commentRepository.GetCommentWithBlog();
            return _mapper.Map<List<GetCommentWithBlogQueryResult>>(values);
        }
    }
}
