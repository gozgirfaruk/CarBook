using CarBook.Application.Features.Mediator.Queries.BlogQueries;
using CarBook.Application.Features.Mediator.Results.BlogResults;
using CarBook.Application.Interfaces;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.BlogHandlers
{
    public class GetBlogSingleAuhtorQueryHandler : IRequestHandler<GetBlogSingleAuthorQuery, GetBlogSingleAuthorQueryResult>
    {
      private readonly IBlogRepository _blogRepository;

        public GetBlogSingleAuhtorQueryHandler(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public async Task<GetBlogSingleAuthorQueryResult> Handle(GetBlogSingleAuthorQuery request, CancellationToken cancellationToken)
        {
            var values = await _blogRepository.GetBlogSingleAuthor(request.Id);
            return values;

        }
    }
}
