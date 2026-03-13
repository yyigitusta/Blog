using Blog.Application.Features.Socials.Commands;
using Blog.Application.Features.Socials.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Endpoints
{
    public static class SocialEndPoints
    {
        public static void RegisterSocialEndpoints(this IEndpointRouteBuilder app)
        {
            var social = app.MapGroup("/social").WithTags("Social");
            social.MapGet("",async(IMediator mediator) =>
            {
                var response = await mediator.Send(new GetSocialQuery());
                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            });
            social.MapGet("{id}",async(Guid id,IMediator mediator) =>
            {
                var response = await mediator.Send(new GetSocialByIdQuery(id));
                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            });
            social.MapPost("",async([AsParameters] CreateSocialCommand command,IMediator mediator) =>
            {
                var response = await mediator.Send(command);
                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            });
            social.MapDelete("{id}",async(Guid id ,IMediator mediator) =>
            {
                var response = await mediator.Send(new DeleteSocialCommand(id));
                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            });
            social.MapPut("{id}",async(Guid id, [AsParameters] UpdateSocialCommand command,IMediator mediator) =>
            {
                if (id != command.Id)
                {
                    return Results.BadRequest("Id'ler eşleşmiyor.");
                }
                var response = await mediator.Send(command);
                return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
            });

        }
    }
}
