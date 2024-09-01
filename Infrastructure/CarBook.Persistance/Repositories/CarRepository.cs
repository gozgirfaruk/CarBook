using AutoMapper;
using CarBook.Application.Features.Mediator.Results.CarResults;
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
    public class CarRepository : ICarRepository
    {
        private readonly CarbookContext _context;
        private readonly IMapper _mapper;
        public CarRepository(CarbookContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<GetCarWithBrandQueryResult>> GetCarWithBrand()
        {
            var values = await _context.Cars.Include(x=>x.Brand).ToListAsync();
            return _mapper.Map<List<GetCarWithBrandQueryResult>>(values);
        }
    }
}
