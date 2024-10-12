using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Dtos.CommentDtos
{
    public class LeaveCommentDto
    {
            public string name { get; set; }
            public DateTime createdDate { get; set; }
            public string content { get; set; }
        public string email { get; set; }
        public int blogId { get; set; }
        
    }
}
