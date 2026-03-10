using Blog.Application.Features.Messages.Command;
using Blog.Application.Features.Messages.Queries;
using MediatR;

namespace Blog.API.Endpoints
{
    public static class MessageEndPoints
    {
        public static void RegisterMessageEndpoints(this IEndpointRouteBuilder app)
        {
            var messages = app.MapGroup("/messages").WithTags("Messages");
            messages.MapPost("", async (CreateMessageCommand command, IMediator mediator) =>
            {
                var response = await mediator.Send(command);
                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            });
            messages.MapDelete("{id}", async (Guid id , IMediator mediator) =>
            {
                var response = await mediator.Send(new RemoveMessageCommand(id));
                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);

            });
            messages.MapPut("{id}" , async (Guid id , UdpateMessageCommand command , IMediator mediator) =>
            {
                if (id != command.Id)
                {
                    return Results.BadRequest("Id in the URL does not match Id in the request body.");
                }
                var response = await mediator.Send(command);
                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            });
            messages.MapGet("" , async (IMediator mediator) =>
            {
                var response = await mediator.Send(new GetMessageQuery());
                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            });
            messages.MapGet("{id}" , async (Guid id , IMediator mediator) =>
            {
                var response = await mediator.Send(new GetMessageByIdQuery(id));
                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            });

        }
    }
}
