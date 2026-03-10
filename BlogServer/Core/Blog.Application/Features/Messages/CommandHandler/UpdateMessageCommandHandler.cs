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
    public class UpdateMessageCommandHandler(IRepository<Message> repository , IUnitOfWork unitOfWork , IMapper mapper) : IRequestHandler<UdpateMessageCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(UdpateMessageCommand request, CancellationToken cancellationToken)
        {
          var message = mapper.Map<Message>(request);
            repository.Update(message);
             await unitOfWork.SaveChangesAsync();
            return BaseResult<object>.Success(message);

        }
    }
}
