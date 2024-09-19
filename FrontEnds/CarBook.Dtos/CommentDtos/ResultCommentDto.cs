﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Dtos.CommentDtos
{
    public class ResultCommentDto
    {
        public int CommentId { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Content { get; set; }
        public int BlogId { get; set; }
    }
}
