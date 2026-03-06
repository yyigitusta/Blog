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
    public class GetBlogByCategoryIdQueryHandler(IRepository <eBlog> repository , IMapper mapper) : IRequestHandler<GetBlogByCategoryIdQuery, BaseResult<List<GetBlogByCategoryIdQueryResult>>>
    {
        public async Task<BaseResult<List<GetBlogByCategoryIdQueryResult>>> Handle(GetBlogByCategoryIdQuery request, CancellationToken cancellationToken)
        {
            var query =  repository.GetQuery();
            var values = query.Where(x => x.CategoryId == request.Id).ToList();
            var blogs = mapper.Map<List<GetBlogByCategoryIdQueryResult>>(values);
            return BaseResult<List<GetBlogByCategoryIdQueryResult>>.Success(blogs);
        }
    }
}
