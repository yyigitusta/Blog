using Blog.Application.Features.Base;
using Blog.Application.Features.Blogs.Result;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Features.Blogs.Queries
{
    public record GetBlogByIdQuery(Guid Id) : IRequest<BaseResult<GetBlogByIdQueryResult>>
    {
    }
}
