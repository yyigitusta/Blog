using AutoMapper;
using Blog.Application.Contracts.Persistence;
using Blog.Application.Features.Base;
using Blog.Application.Features.Messages.Command;
using Blog.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Features.Messages.CommandHandler
{
    public class RemoveMessageCommandHandler(IUnitOfWork unitOfWork , IRepository<Message> repository ,IMapper mapper) : IRequestHandler<RemoveMessageCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(RemoveMessageCommand request, CancellationToken cancellationToken)
        {
            var comment = await repository.GetByIdAsync(request.Id);
            repository.Delete(comment);
            await unitOfWork.SaveChangesAsync();
            return BaseResult<object>.Success(comment);
        }
    }
}
