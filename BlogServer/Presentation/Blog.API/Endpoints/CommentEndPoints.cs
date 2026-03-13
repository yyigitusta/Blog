using Blog.Application.Features.Comments.Commands;
using Blog.Application.Features.Comments.Queries;
using MediatR;

namespace Blog.API.Endpoints
{
    public static class CommentEndPoints
    {
        public static void RegisterCommentEndpoints(this IEndpointRouteBuilder app)
        {
            var comments = app.MapGroup("/comments").WithTags("Comments");
            comments.MapGet(string.Empty, async (IMediator mediator) =>
            {
                var response = await mediator.Send(new GetCommentsQuery());
                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            });
            comments.MapPost(string.Empty, async ([AsParameters] CreateCommentCommand command,IMediator mediator) =>
            {
                var response = await mediator.Send(command);
                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            });
            comments.MapGet("{id}", async (Guid id, IMediator mediator) =>
            {
                var response = await mediator.Send(new GetCommentByIdQuery(id));
                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            });
            comments.MapPut(string.Empty, async ([AsParameters] UpdateCommentCommand command, IMediator mediator) =>
            {
                var response = await mediator.Send(command);
                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            });
            comments.MapDelete("{id}", async (Guid id, IMediator mediator) =>
            {
                var response = await mediator.Send(new RemoveCommentCommand(id));
                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            });
        }
    }
}
