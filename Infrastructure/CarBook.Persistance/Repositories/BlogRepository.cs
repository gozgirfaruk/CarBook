using AutoMapper;
using CarBook.Application.Features.Mediator.Results.BlogResults;
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
    public class BlogRepository : IBlogRepository
    {
        private readonly CarbookContext _context;
        private readonly IMapper _mapper;

        public BlogRepository(CarbookContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GetBlogSingleAuthorQueryResult> GetBlogSingleAuthor(int id)
        {
            var values = await _context.Blogs.Where(x => x.BlogId == id).Include(y => y.Author).FirstOrDefaultAsync();
            return _mapper.Map<GetBlogSingleAuthorQueryResult>(values);
        }

        public async Task<List<GetBlogSingleCommentQueryResult>> GetBlogSingleComment(int id)
        {
            var values = await _context.Comments.Where(x => x.BlogId == id).ToListAsync();
            return _mapper.Map<List<GetBlogSingleCommentQueryResult>>(values);
        }

        public async Task<List<GetBlogWithAuthorQueryResult>> GetBlogWithAuthor()
        {
            var values = await _context.Blogs.Include(x=>x.Author).Include(y=>y.Category).ToListAsync();
          
           return _mapper.Map<List<GetBlogWithAuthorQueryResult>>(values);
        }
    }
}
