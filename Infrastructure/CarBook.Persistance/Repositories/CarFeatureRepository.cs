using AutoMapper;
using CarBook.Application.Features.Mediator.Results.CarFeatureResults;
using CarBook.Application.Interfaces;
using CarBook.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public async Task<List<GetCarFeatureByCarIdQueryResult>> GetFeatureListById(int id)
        {
            var values = await _context.CarFeatures.Include(x => x.Feature).Where(y => y.CarId == id).ToListAsync();
            return _mapper.Map<List<GetCarFeatureByCarIdQueryResult>>(values);
        }
    }
}
