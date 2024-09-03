using AutoMapper;
using CarBook.Application.Features.Mediator.Queries.BlogQueries;
using CarBook.Application.Features.Mediator.Results.AboutResults;
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
    public class GetByIdBlogQueryHandler : IRequestHandler<GetByIdBlogQuery, GetByIdBlogQueryResult>
    {
        private readonly IRepository<Blog> _repository;
        private readonly IMapper _mapper;

        public GetByIdBlogQueryHandler(IRepository<Blog> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<GetByIdBlogQueryResult> Handle(GetByIdBlogQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            return _mapper.Map<GetByIdBlogQueryResult>(values);

        }
    }
}
