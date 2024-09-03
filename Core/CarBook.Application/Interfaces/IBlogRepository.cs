using CarBook.Application.Features.Mediator.Results.BlogResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Interfaces
{
    public interface IBlogRepository
    {
        Task<List<GetBlogWithAuthorQueryResult>> GetBlogWithAuthor();
    }
}
