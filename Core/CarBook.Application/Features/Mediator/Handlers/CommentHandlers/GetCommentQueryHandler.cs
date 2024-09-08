using AutoMapper;
using CarBook.Application.Features.Mediator.Queries.CommentQueries;
using CarBook.Application.Features.Mediator.Results.CommentResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.CommentHandlers
{
    public class GetCommentQueryHandler : IRequestHandler<GetCommenQuery, List<GetCommentQueryResult>>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Comment> _repository;
        public GetCommentQueryHandler(IMapper mapper, IRepository<Comment> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<List<GetCommentQueryResult>> Handle(GetCommenQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return _mapper.Map<List<GetCommentQueryResult>>(values);
        }
    }
}
