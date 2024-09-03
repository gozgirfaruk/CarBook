﻿using AutoMapper;
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

        public async Task<List<GetBlogWithAuthorQueryResult>> GetBlogWithAuthor()
        {
            var values = await _context.Blogs.Include(x=>x.Author).ToListAsync();
           return _mapper.Map<List<GetBlogWithAuthorQueryResult>>(values);
        }
    }
}
