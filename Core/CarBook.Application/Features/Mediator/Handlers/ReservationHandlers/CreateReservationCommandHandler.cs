using AutoMapper;
using CarBook.Application.Features.Mediator.Commands.ReservationCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.ReservationHandlers
{
    public class CreateReservationCommandHandler : IRequestHandler<CreateReservationCommand>
    {
        private readonly IRepository<Reservation> _repository;
        private readonly IMapper _mapper;

        public CreateReservationCommandHandler(IRepository<Reservation> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        
        public async Task Handle(CreateReservationCommand request, CancellationToken cancellationToken)
        {
           
           var values = _mapper.Map<Reservation>(request);
            values.Status = "Rezervasyon Alındı";
           await _repository.CreateAsyc(values);
        }
    }
}
