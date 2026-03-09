using Blog.Application.Features.Base;
using Blog.Application.Features.Comments.Results;
using Blog.Application.Features.Users.Quaries;
using Blog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Features.SubComments.Results
{
    public class GetSubCommentsQueryResult : BaseDto
    {
        public string UserId { get; set; }
        public string Body { get; set; }
        public DateTime CommentDate { get; set; }
        public Guid CommentId { get; set; }
        public GetUserQueryResult User { get; set; }
        GetCommentsQueryResult Comment { get; set; }
    }
}
