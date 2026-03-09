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
    public class CreateCommentCommandHandler (IMapper mapper,IUnitOfWork unitOfWork,IRepository<Comment> repository)
        : IRequestHandler<CreateCommentCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = mapper.Map<Comment>(request);
            await repository.CreateAsync(comment);
            await unitOfWork.SaveChangesAsync();
            return BaseResult<object>.Success(comment);
        }
    }
}
