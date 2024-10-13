using AutoMapper;
using CarBook.Application.Features.Mediator.Results.CarFeatureResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using CarBook.Persistance.Context;
using Microsoft.EntityFrameworkCore;

namespace CarBook.Persistance.Repositories
{
    public class CarFeatureRepository : ICarFeatureRepository
    {
        private readonly CarbookContext _context;
        private readonly IMapper _mapper;

        public CarFeatureRepository(CarbookContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async void ChangeCarFeatureAvailableToFalse(int id)
        {
            var values = _context.CarFeatures.Where(x => x.CarFeatureId == id).FirstOrDefault();
            values.Available = false;
            _context.SaveChangesAsync();
        }

        public async void ChangeCarFeatureAvailableToTrue(int id)
        {
            var values = _context.CarFeatures.Where(x => x.CarFeatureId == id).FirstOrDefault();
            values.Available = true;
            _context.SaveChangesAsync();
        }

        public void CreateCarFeatureByCar(CarFeature feature)
        {
            _context.CarFeatures.Add(feature);
            _context.SaveChanges();
        }

        public async Task<List<GetCarFeatureByCarIdQueryResult>> GetFeatureListById(int id)
        {
            var values = await _context.CarFeatures.Include(x => x.Feature).Where(y => y.CarId == id).ToListAsync();
            return _mapper.Map<List<GetCarFeatureByCarIdQueryResult>>(values);
        }
    }
}
