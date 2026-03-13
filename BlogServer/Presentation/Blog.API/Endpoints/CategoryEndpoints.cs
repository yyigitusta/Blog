using Blog.Application.Features.Categories.Commands;
using Blog.Application.Features.Categories.Queries;
using MediatR;

namespace Blog.API.Endpoints
{
    public static class CategoryEndpoints
    {
        public static void RegisterCategoryEndpoints(this IEndpointRouteBuilder app)
        {
            var categories = app.MapGroup("/categories").WithTags("Categories");


            categories.MapGet(string.Empty, async (IMediator _mediator) =>
            {
                var response = await _mediator.Send(new GetCategoryQuery());
                return response.IsSuccess ? Results.Ok(response)
                    : Results.BadRequest(response);
            }
            );

            categories.MapPost(string.Empty, async ([AsParameters] CreateCategoryCommand command,  IMediator _mediator) =>
            {
                var response = await _mediator.Send(command);
                return response.IsSuccess ? Results.Ok(response)
                    : Results.BadRequest(response);
            });

            categories.MapGet("{id}", async (Guid id, IMediator _mediator) =>
            {
                var response = await _mediator.Send(new GetCategoryByIdQuery(id));
                return response.IsSuccess ? Results.Ok(response)
                    : Results.BadRequest(response);
            });

            categories.MapPut(string.Empty, async ([AsParameters] UpdateCategoryCommand command, IMediator _mediator) =>
            {
                var response = await _mediator.Send(command);
                return response.IsSuccess ? Results.Ok(response)
                    : Results.BadRequest(response);
            });

            categories.MapDelete("{id}", async (Guid id, IMediator _mediator) =>
            {
                var response = await _mediator.Send(new RemoveCategoryCommand(id));
                return response.IsSuccess ? Results.Ok(response)
                    : Results.BadRequest(response);
            });

        }
    }
}
