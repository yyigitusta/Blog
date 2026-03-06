using Blog.Application.Features.Blogs.Commands;
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
            blogs.MapPost(string.Empty, async (CreateBlogCommand command, IMediator _mediator) =>
            {
                var response = await _mediator.Send(command);
                return response.IsSuccess ? Results.Ok(response)
                    : Results.BadRequest(response);
            });
            blogs.MapGet("{id}", async (Guid id, IMediator _mediator) =>
            {
                var response = await _mediator.Send(new GetBlogByIdQuery(id));
                return response.IsSuccess ? Results.Ok(response)
                    : Results.BadRequest(response);
            });
            blogs.MapPut(string.Empty, async (UpdateBlogCommand command, IMediator _mediator) =>
            {

                var response = await _mediator.Send(command);
                return response.IsSuccess ? Results.Ok(response)
                    : Results.BadRequest(response);
            });
            blogs.MapDelete("{id}", async (Guid id, IMediator _mediator) =>
            {
                var response = await _mediator.Send(new RemoveBlogCommand(id));
                return response.IsSuccess ? Results.Ok(response)
                    : Results.BadRequest(response);
            });
            blogs.MapGet("byCategoryID/{categoryId}", async (Guid categoryId, IMediator _mediator) =>
            {
                var response = await _mediator.Send(new GetBlogByCategoryIdQuery(categoryId));
                return response.IsSuccess ? Results.Ok(response)
                    : Results.BadRequest(response);
            });
        }
    }
}
