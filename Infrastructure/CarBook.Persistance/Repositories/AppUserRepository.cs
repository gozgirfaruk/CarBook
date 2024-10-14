using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using CarBook.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistance.Repositories
{
	public class AppUserRepository : IAppUserRepository
	{
		private readonly CarbookContext _context;
		public AppUserRepository(CarbookContext context)
		{
			_context = context;
		}
		public Task<List<AppUser>> GetByFilterAsync(Expression<Func<AppUser, bool>> filter)
		{
			throw new NotImplementedException();
		}
	}
}
