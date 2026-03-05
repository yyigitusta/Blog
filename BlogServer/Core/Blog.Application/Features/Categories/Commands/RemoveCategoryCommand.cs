using Blog.Application.Features.Base;
using MediatR;

namespace Blog.Application.Features.Categories.Commands
{
    public record RemoveCategoryCommand(Guid Id) : IRequest<BaseResult<bool>>;
  
}
