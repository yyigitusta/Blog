using Blog.Application.Features.ContacInfos.Command;
using Blog.Application.Features.ContacInfos.Queries;
using MediatR;

namespace Blog.API.Endpoints
{
    public static class ContacInfoEndPoints
    {
        public static void RegisterContactInfoEndpoints(this IEndpointRouteBuilder app)
        {
            var contactInfo = app.MapGroup("/contact-info").WithTags("Contact Info");
            contactInfo.MapGet(string.Empty, async (IMediator mediator) =>
            {
                var response = await mediator.Send(new GetContacInfoQuery());
                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            });
            contactInfo.MapGet("{id}", async (Guid id, IMediator mediator) =>
            {
                var response = await mediator.Send(new GetContacInfoByIdQuery(id));
                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            });
            contactInfo.MapPost(string.Empty, async (CreateContactInfoCommand command, IMediator mediator) =>
            {
                var response = await mediator.Send(command);
                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            });
            contactInfo.MapPut("{id}", async (Guid id, UpdateContactInfoCommand command, IMediator mediator) =>
            {
                if (id != command.Id)
                {
                    return Results.BadRequest("Id in the URL does not match Id in the body.");
                }
                var response = await mediator.Send(command);
                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            });
            contactInfo.MapDelete("{id}", async (Guid id, RemoveContacInfoCommand command, IMediator mediator) =>
            {
                if (id != command.id)
                {
                    return Results.BadRequest("Id in the URL does not match Id in the body.");
                }
                var response = await mediator.Send(command);
                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            });

        }
    }
}
