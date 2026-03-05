using Blog.Application.Features.Base;
using Blog.Application.Features.Blogs.Result;
using MediatR;

namespace Blog.Application.Features.Blogs.Queries
{
    public class GetBlogsQuery : IRequest<BaseResult<List<GetBlogsQueryResult>>>
    {
    }
}
