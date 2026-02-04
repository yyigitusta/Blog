using Blog.Application.Features.Base;
using Blog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Features.Categories.Results
{
    public class GetCategoryQueryResult:BaseDto
    {
        public string CategoryName { get; set; }
       // public IList<GeteBlogQueryResult> Blogs { get; set; }
    }
}
