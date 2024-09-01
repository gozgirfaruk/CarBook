using AutoMapper;
using CarBook.Application.Features.Mediator.Queries.SocialMediaQueries;
using CarBook.Application.Features.Mediator.Results.SocialMediaResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.SocialMediaHandlers
{
    public class GetByIdSocialMediaQueryHandler : IRequestHandler<GetByıdSocialMediaQuery, GetByIdSocialMediaQueryResult>
    {
        private readonly IRepository<SocialMedia> _repository;
        private readonly IMapper _mapper;
        public GetByIdSocialMediaQueryHandler(IRepository<SocialMedia> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetByIdSocialMediaQueryResult> Handle(GetByıdSocialMediaQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            return _mapper.Map<GetByIdSocialMediaQueryResult>(values);
        }
    }
}
