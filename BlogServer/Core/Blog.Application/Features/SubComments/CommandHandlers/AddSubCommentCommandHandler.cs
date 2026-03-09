using AutoMapper;
using Blog.Application.Contracts.Persistence;
using Blog.Application.Features.Base;
using Blog.Application.Features.SubComments.Commands;
using Blog.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Features.SubComments.CommandHandlers
{
    public class AddSubCommentCommandHandler(IRepository<SubComment> repository , IUnitOfWork unitOfWork , IMapper mapper) : IRequestHandler<AddSubCommentCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(AddSubCommentCommand request, CancellationToken cancellationToken)
        {
            var subComment = mapper.Map<SubComment>(request);
            await repository.CreateAsync(subComment);
            var result = await unitOfWork.SaveChangesAsync();
            return result ? BaseResult<object>.Success(subComment) : BaseResult<object>.Fail("Failed to add sub comment");
        }
    }
}
