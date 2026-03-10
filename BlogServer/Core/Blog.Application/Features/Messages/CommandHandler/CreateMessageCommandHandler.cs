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
    public class CreateMessageCommandHandler(IUnitOfWork unitOfWork , Mapper mapper , IRepository<Message> repository) : IRequestHandler<CreateMessageCommand, BaseResult<object>>
    {
        public async  Task<BaseResult<object>> Handle(CreateMessageCommand request, CancellationToken cancellationToken)
        {
            var message = mapper.Map<Message>(request); 
            await repository.CreateAsync(message);
            await unitOfWork.SaveChangesAsync();
            return BaseResult<object>.Success(message);
        }
    }
}
