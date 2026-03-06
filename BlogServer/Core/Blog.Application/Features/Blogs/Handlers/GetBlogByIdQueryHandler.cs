using AutoMapper;
using Blog.Application.Contracts.Persistence;
using Blog.Application.Features.Base;
using Blog.Application.Features.Blogs.Queries;
using Blog.Application.Features.Blogs.Result;
using Blog.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Features.Blogs.Handlers
{
    public class GetBlogByIdQueryHandler(IMapper mapper,IRepository<eBlog> repository) : IRequestHandler<GetBlogByIdQuery, BaseResult<GetBlogByIdQueryResult>>
    {
        public async Task<BaseResult<GetBlogByIdQueryResult>> Handle(GetBlogByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await repository.GetByIdAsync(request.Id);
            if (value == null)
            {
                return BaseResult<GetBlogByIdQueryResult>.NotFound("Blog not found");
            }
            var blog = mapper.Map<GetBlogByIdQueryResult>(value);
            return BaseResult<GetBlogByIdQueryResult>.Success(blog);
        }
    }
}
