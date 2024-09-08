using AutoMapper;
using CarBook.Application.Features.Mediator.Results.CommentResults;
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
    public class CommentRepository : ICommentRepository
    {
        private readonly CarbookContext _context;
        private readonly IMapper _mapper;

        public CommentRepository(CarbookContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<GetCommentQueryResult>> GetCommentByBlog(int id)
        {
            var values = await _context.Comments.Where(x => x.BlogId == id).ToListAsync();
            return _mapper.Map<List<GetCommentQueryResult>>(values);
        }
    }
}
