using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Domain.Entities.Common;

namespace Blog.Domain.Entities
{
    public class Comment : BaseEntitiy
    {
        public string UserId { get; set; }
        public string Body { get; set; }
        public DateTime CommentDate { get; set; }
        public virtual IList<SubComment> SubComments { get; set; }
        public virtual AppUser User { get; set; }
        public Guid BlogId { get; set; }
        public virtual eBlog Blog { get; set; }

    }
}
