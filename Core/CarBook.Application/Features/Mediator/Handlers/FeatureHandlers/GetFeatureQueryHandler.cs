using AutoMapper;
using CarBook.Application.Features.Mediator.Queries.FeatureQueries;
using CarBook.Application.Features.Mediator.Results.FeatureReuslts;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.FeatureHandlers
{
    public class GetFeatureQueryHandler : IRequestHandler<GetFeatureQuery, List<GetFeatureQueryResult>>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Feature> _repository;
        public GetFeatureQueryHandler(IMapper mapper, IRepository<Feature> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<List<GetFeatureQueryResult>> Handle(GetFeatureQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return _mapper.Map<List<GetFeatureQueryResult>>(values);
        }
    }
}
