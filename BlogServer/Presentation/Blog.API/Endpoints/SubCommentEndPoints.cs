using Blog.Application.Features.SubComments.Commands;
using Blog.Application.Features.SubComments.Queries;
using MediatR;

namespace Blog.API.Endpoints
{
    public static class SubCommentEndPoints
    {
        public static void RegisterSubCommentEndpoints(this IEndpointRouteBuilder app)
        {
            var subComments = app.MapGroup("/subcomments").WithTags("SubComments");
            subComments.MapPost(string.Empty, async (IMediator mediator, [AsParameters] AddSubCommentCommand command) =>
            {
                var response = await mediator.Send(command);
                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            });
            subComments.MapGet("", async (IMediator mediator, [AsParameters] GetSubCommentQuery query) =>
            {
                var response = await mediator.Send(query);
                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            });
            subComments.MapGet("{id}", async (Guid id, IMediator mediator) =>
            {
                var response = await mediator.Send(new GetSubCommentByIdQuery(id));
            });
            subComments.MapPut("", async (IMediator mediator, [AsParameters] UpdateSubCommentCommand command) =>
            {
                var response = await mediator.Send(command);
                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);

            });
            subComments.MapDelete("{id}", async (Guid id, IMediator mediator) =>
            {
                var response = await mediator.Send(new RemoveSubCommentCommand(id));
                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            });
        }
    }
}
