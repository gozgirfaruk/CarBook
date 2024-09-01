using CarBook.Application.Features.Mediator.Commands.AddressCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.AddressHandlers
{
    public class RemoveAddressCommandHandler : IRequestHandler<RemoveAddressCommand>
    {
        private readonly IRepository<FooterAdress> _repository;

        public RemoveAddressCommandHandler(IRepository<FooterAdress> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveAddressCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            await _repository.DeleteAsync(values);
        }
    }
}
