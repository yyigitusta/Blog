using Blog.Application.Features.Base;
using MediatR;

namespace Blog.Application.Features.Categories.Commands
{
    public record UpdateCategoryCommand(Guid Id,string CategoryName) : IRequest<BaseResult<bool>>;
    
}
