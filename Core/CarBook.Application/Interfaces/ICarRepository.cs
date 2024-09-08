using CarBook.Application.Features.Mediator.Results.CarResults;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Interfaces
{
    public interface ICarRepository
    {
        Task<List<GetCarWithBrandQueryResult>> GetCarWithBrand();
        Task<List<GetCarWithPricingQueryResult>> GetCarWithPricings();
    }
}
