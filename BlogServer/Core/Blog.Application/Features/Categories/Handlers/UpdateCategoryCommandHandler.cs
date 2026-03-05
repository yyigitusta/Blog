using AutoMapper;
using Blog.Application.Contracts.Persistence;
using Blog.Application.Features.Base;
using Blog.Application.Features.Categories.Commands;
using Blog.Domain.Entities;
using MediatR;

namespace Blog.Application.Features.Categories.Handlers
{
    public class UpdateCategoryCommandHandler(IRepository<Category> repository, IMapper _mapper, IUnitOfWork unitOfWork):
        IRequestHandler<UpdateCategoryCommand, BaseResult<bool>>
    {
        public async Task<BaseResult<bool>> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = _mapper.Map<Category>(request);
            repository.Update(category);
            var response = await unitOfWork.SaveChangesAsync();

            return response ? BaseResult<bool>.Success(response) :
                BaseResult<bool>.Fail("Failed to update the category.");
        }
    }
}
