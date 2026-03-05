using AutoMapper;
using Blog.Application.Contracts.Persistence;
using Blog.Application.Features.Base;
using Blog.Application.Features.Blogs.Queries;
using Blog.Application.Features.Blogs.Result;
using Blog.Domain.Entities;
using MediatR;

namespace Blog.Application.Features.Blogs.Handlers
{
    public class GetBlogsQueryHandler(IRepository<eBlog> repository,IMapper mapper) : IRequestHandler<GetBlogsQuery, BaseResult<List<GetBlogsQueryResult>>>
    {
        public async Task<BaseResult<List<GetBlogsQueryResult>>> Handle(GetBlogsQuery request, CancellationToken cancellationToken)
        {
            var values = await repository.GetAllAsync();
            var blogs = mapper.Map<List<GetBlogsQueryResult>>(values);
            return BaseResult<List<GetBlogsQueryResult>>.Success(blogs);
        }
    }
}
