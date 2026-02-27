using Blog.Application.Features.Base;
using FluentValidation;

namespace Blog.API.CustomMiddlewares
{
    public class CustomExceptionHandlingMiddleware(RequestDelegate next)
    {
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (ValidationException ex)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                context.Response.ContentType = "application/json";
                var response = new BaseResult<object>()
                {
                    Errors = ex.Errors.GroupBy(e => e.PropertyName).Select(x => new Error()
                    {
                        PropertyName = x.Key,
                        ErrorMessage = x.Select(e => e.ErrorMessage).FirstOrDefault()
                    }).ToList()
                };
                await context.Response.WriteAsJsonAsync(response);
            }
            catch(Exception ex)
            {
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                await context.Response.WriteAsJsonAsync(new { errorMessage = ex.Message });
            }
        }
    }
}
