using Blog.Application.Contracts.Persistence;
using Blog.Application.Features.Base;
using Blog.Application.Features.Categories.Commands;
using Blog.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Features.Categories.Handlers
{
    public class RemoveCategoryCommandHandler(IRepository<Category> repository,IUnitOfWork unitOfWork) : IRequestHandler<RemoveCategoryCommand, BaseResult<bool>>
    {
        public async Task<BaseResult<bool>> Handle(RemoveCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await repository.GetByIdAsync(request.Id);
            if (category == null)
            {
                return BaseResult<bool>.NotFound("Category not found");
            }
            repository.Delete(category);
            return  await unitOfWork.SaveChangesAsync() ? BaseResult<bool>.Success(await unitOfWork.SaveChangesAsync())
                : BaseResult<bool>.Fail("Category couldn't be deleted");

        }
    }
}
