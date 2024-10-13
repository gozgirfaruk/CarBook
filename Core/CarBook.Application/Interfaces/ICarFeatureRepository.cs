using CarBook.Application.Features.Mediator.Results.CarFeatureResults;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Interfaces
{
    public interface ICarFeatureRepository
    {
        Task<List<GetCarFeatureByCarIdQueryResult>> GetFeatureListById(int id);
        void ChangeCarFeatureAvailableToFalse(int id);
        void ChangeCarFeatureAvailableToTrue(int id);

        void CreateCarFeatureByCar(CarFeature feature);

    }
}
