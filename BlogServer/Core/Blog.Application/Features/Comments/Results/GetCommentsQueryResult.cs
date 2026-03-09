using Blog.Application.Features.Base;
using Blog.Application.Features.Blogs.Result;
using Blog.Application.Features.Users.Quaries;
using Blog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Features.Comments.Results
{
    public class GetCommentsQueryResult : BaseDto
    {
        public string UserId { get; set; }
        public string Body { get; set; }
        public DateTime CommentDate { get; set; }
       // public virtual IList<SubComment> SubComments { get; set; }
        public  GetUserQueryResult User { get; set; }
        public Guid BlogId { get; set; }
        public GetBlogsQueryResult Blog { get; set; }

    }
}
