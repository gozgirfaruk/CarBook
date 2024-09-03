using AutoMapper;
using CarBook.Application.Features.Mediator.Queries.BlogQueries;
using CarBook.Application.Features.Mediator.Results.BlogResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.BlogHandlers
{
    public class GetBlogWithAuthorQueryHandler : IRequestHandler<GetBlogWithAuthorQuery, List<GetBlogWithAuthorQueryResult>>
    {
   
        private readonly IBlogRepository _blogRepository;

        public GetBlogWithAuthorQueryHandler(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public async Task<List<GetBlogWithAuthorQueryResult>> Handle(GetBlogWithAuthorQuery request, CancellationToken cancellationToken)
        {
            var values = await _blogRepository.GetBlogWithAuthor();
            return values.ToList();
        }
    }
}
