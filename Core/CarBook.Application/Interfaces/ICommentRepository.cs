using CarBook.Application.Features.Mediator.Results.CommentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Interfaces
{
    public interface ICommentRepository
    {
        Task<List<GetCommentQueryResult>> GetCommentByBlog(int id);
        Task<List<GetCommentWithBlogQueryResult>> GetCommentWithBlog();
    }
}
