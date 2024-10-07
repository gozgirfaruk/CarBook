using AutoMapper;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using CarBook.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CarBook.Persistance.Repositories
{
    public class RentACarRepository : IRentACarRepository
    {
        private readonly CarbookContext _context;
        private readonly IMapper _mapper;
        public RentACarRepository(CarbookContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<RentACar>> GetByFilterAsync(Expression<Func<RentACar, bool>> filter)
        {
            var values = await _context.RentACars.Where(filter).Include(x=>x.Car).ThenInclude(y=>y.Brand).ToListAsync();
            return values;
        }
    }
}
