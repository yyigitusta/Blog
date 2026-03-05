using Blog.Application.Features.Blogs.Queries;
using MediatR;

namespace Blog.API.Endpoints
{
    public static class BlogEndPoints
    {
        public static void RegisterBlogEndpoints(this IEndpointRouteBuilder app)
        {
           var blogs = app.MapGroup("/blogs").WithTags("Blogs");


            blogs.MapGet(string.Empty, async (IMediator _mediator) =>
            {
                var response = await _mediator.Send(new GetBlogsQuery());
                return response.IsSuccess ? Results.Ok(response)
                    : Results.BadRequest(response);
            }
            );
        }
    }
}
