using Blog.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Domain.Entities
{
    public class SubComment:BaseEntitiy
    {
        public string UserId { get; set; }
        public string Body { get; set; }
        public DateTime CommentDate { get; set; }
        public Guid CommentId { get; set; }
        public virtual Comment Comment { get; set; }
        public virtual AppUser User { get; set; }
    }
}
