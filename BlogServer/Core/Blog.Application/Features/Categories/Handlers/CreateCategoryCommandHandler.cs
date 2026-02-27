using AutoMapper;
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
    public class CreateCategoryCommandHandler(IRepository<Category> _repository,IUnitOfWork _unitOfWork,IMapper _mapper) : IRequestHandler<CreateCategoryCommand, BaseResult<bool>>
    {
        public async Task<BaseResult<bool>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = _mapper.Map<Category>(request);
            await _repository.CreateAsync(category);
            var result = await _unitOfWork.SaveChangesAsync();
            return result ? BaseResult<bool>.Success(true) : BaseResult<bool>.Fail("Failed to create category");
        }
    }
}
