using AutoMapper;
using CarBook.Application.Features.Mediator.Commands.TestimonialCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.TestimonialHandlers
{
    public class UpdateTestimonialCommandHandler : IRequestHandler<UpdateTestimonialCommand>
    {
        private readonly IRepository<Testimonial> _repository;
        private readonly IMapper _mapper;

        public UpdateTestimonialCommandHandler(IRepository<Testimonial> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(UpdateTestimonialCommand request, CancellationToken cancellationToken)
        {
            var values = _mapper.Map<Testimonial>(request);
            await _repository.UpdateAsync(values);
        }
    }
}
