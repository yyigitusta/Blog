using AutoMapper;
using Blog.Application.Contracts.Persistence;
using Blog.Application.Features.Base;
using Blog.Application.Features.Comments.Commands;
using Blog.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Features.Comments.Handlers
{
    public class RemoveCommentCommandHandler(IRepository<Comment> repository,IUnitOfWork unitOfWork ) : IRequestHandler<RemoveCommentCommand, BaseResult<bool>>
    {
        public async Task<BaseResult<bool>> Handle(RemoveCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = await repository.GetByIdAsync(request.id);
            if (comment == null)
            {
                return BaseResult<bool>.NotFound("Comment not found");
            }
            repository.Delete(comment);
            await unitOfWork.SaveChangesAsync();
            return BaseResult<bool>.Success(true);
        }
    }
}
