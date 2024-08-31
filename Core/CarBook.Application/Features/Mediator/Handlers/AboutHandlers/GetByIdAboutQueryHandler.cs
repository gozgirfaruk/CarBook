using AutoMapper;
using CarBook.Application.Features.Mediator.Queries.AboutQueries;
using CarBook.Application.Features.Mediator.Results.AboutResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.AboutHandlers
{
    public class GetByIdAboutQueryHandler : IRequestHandler<GetByIdAboutQuery, GetByIdAboutQueryResult>
    {
        private readonly IRepository<About> _repository;
        private readonly IMapper _mapper;

        public GetByIdAboutQueryHandler(IRepository<About> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetByIdAboutQueryResult> Handle(GetByIdAboutQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            return _mapper.Map<GetByIdAboutQueryResult>(values);
        }
    }
}
