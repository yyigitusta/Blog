using Blog.Application.Features.Users.Commands;
using Blog.Application.Features.Users.Quaries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Endpoints
{
    public static class UserEndPoints
    {
        public static void RegisterUserEndpoints(this IEndpointRouteBuilder app)
        {
            var users = app.MapGroup("/users").WithTags("Users").AllowAnonymous();
            users.MapGet(string.Empty, () =>
            {
                return Results.Ok("Users endpoint is working");
            });
            users.MapPost("register", async (IMediator _mediator, [AsParameters] CreateUserCommand command) =>
            {
                var response = await _mediator.Send(command);
                return response.IsSuccess ? Results.Ok(response)
                    : Results.BadRequest(response);
            });
            users.MapPost("login",
                async (IMediator mediator,[FromBody] GetLoginQuery query) =>
                {
                    var response = await mediator.Send(query);
                    return response.IsSuccess ? Results.Ok(response)
                   : Results.BadRequest(response);
                });
        }
    }
}
