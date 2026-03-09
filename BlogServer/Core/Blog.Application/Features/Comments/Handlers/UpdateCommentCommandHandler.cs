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
    public class UpdateCommentCommandHandler (IRepository<Comment> repository, IUnitOfWork unitOfWork , IMapper mapper)
        : IRequestHandler<UpdateCommentCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
        {
            var subcomment = await repository.GetByIdAsync(request.Id);
            var comment = mapper.Map<Comment>(subcomment);
            repository.Update(comment);
            var response = await unitOfWork.SaveChangesAsync();

            return BaseResult<object>.Success("Comment Updated Succesfuly");
        }
    }
}
