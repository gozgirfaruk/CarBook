using AutoMapper;
using CarBook.Application.Features.Mediator.Queries.FeatureQueries;
using CarBook.Application.Features.Mediator.Results.FeatureReuslts;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.FeatureHandlers
{
    public class GetByIdFeatureQueryHandler : IRequestHandler<GetByIdFeatureQuery, GetByIdFeatureQueryResult>
    {
        private readonly IRepository<Feature> _repository;
        private readonly IMapper _mapper;
        public GetByIdFeatureQueryHandler(IRepository<Feature> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetByIdFeatureQueryResult> Handle(GetByIdFeatureQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            return _mapper.Map<GetByIdFeatureQueryResult>(values);
        }
    }
}
