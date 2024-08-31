using CarBook.Application.Features.Mediator.Results.AboutResults;
using MediatR;

namespace CarBook.Application.Features.Mediator.Queries.AboutQueries
{
    public class GetByIdAboutQuery : IRequest<GetByIdAboutQueryResult>
    {
        public int Id { get; set; }

        public GetByIdAboutQuery(int id)
        {
            Id = id;
        }
    }
}
