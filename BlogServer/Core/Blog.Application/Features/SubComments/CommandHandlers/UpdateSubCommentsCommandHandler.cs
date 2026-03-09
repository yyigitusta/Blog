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
    public class UpdateSubCommentsCommandHandler(IRepository<SubComment> repository , IUnitOfWork unitOfWork , IMapper mapper) : IRequestHandler<UpdateSubCommentCommand, BaseResult<object>>
    {
        public  async Task<BaseResult<object>> Handle(UpdateSubCommentCommand request, CancellationToken cancellationToken)
        {
            var subComment = await repository.GetByIdAsync(request.id);
            if (subComment == null)
            {
                return BaseResult<object>.Fail("SubComment not found");
            }
            mapper.Map(request, subComment);
            repository.Update(subComment);
            var result = await unitOfWork.SaveChangesAsync();
            return result ? BaseResult<object>.Success(subComment) : BaseResult<object>.Fail("Failed to update subcomment");
        }
    }
}
