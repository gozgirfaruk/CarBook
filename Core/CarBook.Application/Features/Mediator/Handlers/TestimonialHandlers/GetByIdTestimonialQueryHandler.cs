using AutoMapper;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using CarBook.Application.Features.Mediator.Queries.TestimonialQueries;
using CarBook.Application.Features.Mediator.Results.TestimonialResults;

namespace CarBook.Application.Testimonials.Mediator.Handlers.TestimonialHandlers
{
    public class GetByIdTestimonialQueryHandler : IRequestHandler<GetByIdTestimonialQuery, GetByIdTestimonialQueryResult>
    {
        private readonly IRepository<Testimonial> _repository;
        private readonly IMapper _mapper;
        public GetByIdTestimonialQueryHandler(IRepository<Testimonial> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetByIdTestimonialQueryResult> Handle(GetByIdTestimonialQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            return _mapper.Map<GetByIdTestimonialQueryResult>(values);
        }
    }
}
