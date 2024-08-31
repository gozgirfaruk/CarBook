using AutoMapper;
using CarBook.Application.Features.Mediator.Queries.BannerQueries;
using CarBook.Application.Features.Mediator.Results.BannerResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.BannerHandlers
{
    public class GetByIdBannerQueryHandler : IRequestHandler<GetByıdBannerQuery, GetByIdBannerQueryResult>
    {
        private readonly IRepository<Banner> _repository;
        private readonly IMapper _mapper;


        public GetByIdBannerQueryHandler(IMapper mapper, IRepository<Banner> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<GetByIdBannerQueryResult> Handle(GetByıdBannerQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            return _mapper.Map<GetByIdBannerQueryResult>(values);
        }
    }
}
