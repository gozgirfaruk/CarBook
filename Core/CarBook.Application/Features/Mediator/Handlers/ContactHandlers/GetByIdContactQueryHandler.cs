using AutoMapper;
using CarBook.Application.Features.Mediator.Queries.ContactQueries;
using CarBook.Application.Features.Mediator.Results.ContactResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.ContactHandlers
{
    public class GetByIdContactQueryHandler : IRequestHandler<GetByIdContactQuery, GetByIdContactQueryResult>
    {
        private readonly IRepository<Contact> _repository;
        private readonly IMapper _mapper;
        public GetByIdContactQueryHandler(IRepository<Contact> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetByIdContactQueryResult> Handle(GetByIdContactQuery request, CancellationToken cancellationToken)
        {
           var values =await _repository.GetByIdAsync(request.Id);
            return _mapper.Map<GetByIdContactQueryResult>(values);
        }
    }
}
