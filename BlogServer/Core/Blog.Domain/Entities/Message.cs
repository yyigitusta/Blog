using Blog.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Domain.Entities
{
    public class Message:BaseEntitiy
    {
       public string FullName { get; set; }
       public string Email { get; set; }
       public string Subject { get; set; }
       public string MessageBody { get; set; }
        public bool IsRead { get; set; }
    }
}
