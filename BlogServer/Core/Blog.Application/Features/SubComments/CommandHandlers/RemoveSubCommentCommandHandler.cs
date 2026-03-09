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
    public class RemoveSubCommentCommandHandler(IRepository<SubComment> repository , IUnitOfWork unitOfWork) : IRequestHandler<RemoveSubCommentCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(RemoveSubCommentCommand request, CancellationToken cancellationToken)
        {
            var subcomment= await repository.GetByIdAsync(request.subCommentId);
            if (subcomment is null)
            {
                return BaseResult<object>.NotFound("SubComment not found");
            }
             repository.Delete(subcomment);
            var result = await unitOfWork.SaveChangesAsync() ;
            return BaseResult<object>.Success(true);
        }
    }
}
