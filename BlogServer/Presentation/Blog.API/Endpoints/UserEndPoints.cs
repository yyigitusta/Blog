using Blog.Application.Features.Users.Commands;
using MediatR;

namespace Blog.API.Endpoints
{
    public static class UserEndPoints
    {
        public static void RegisterUserEndpoints(this IEndpointRouteBuilder app)
        {
            var users = app.MapGroup("/users").WithTags("Users");
            users.MapGet(string.Empty, () =>
            {
                return Results.Ok("Users endpoint is working");
            });
            users.MapPost("register", async (IMediator _mediator, CreateUserCommand command) =>
            {
                var response = await _mediator.Send(command);
                return response.IsSuccess ? Results.Ok(response)
                    : Results.BadRequest(response);
            });
        }
    }
}
