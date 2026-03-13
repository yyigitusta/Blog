using Blog.Application.Features.Base;
using Blog.Application.Features.Blogs.Result;
using Blog.Application.Features.Users.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Features.Comments.Results
{
    public class GetCommentByIdQueryResult : BaseDto
    {
        public string UserId { get; set; }
        public string Body { get; set; }
        public DateTime CommentDate { get; set; }
        // public virtual IList<SubComment> SubComments { get; set; }
        public GetUserQueryResult User { get; set; }
        public Guid BlogId { get; set; }
        public GetBlogsQueryResult Blog { get; set; }
    }
}
