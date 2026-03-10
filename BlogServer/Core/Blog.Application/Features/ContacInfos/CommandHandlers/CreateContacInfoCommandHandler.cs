using AutoMapper;
using Blog.Application.Contracts.Persistence;
using Blog.Application.Features.Base;
using Blog.Application.Features.ContacInfos.Command;
using Blog.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Features.ContacInfos.CommandHandlers
{
    public class CreateContacInfoCommandHandler(IMapper mapper , IUnitOfWork unitOfWork , IRepository<ContacInfo> repository) : IRequestHandler<CreateContactInfoCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(CreateContactInfoCommand request, CancellationToken cancellationToken)
        {
            var contactInfo = mapper.Map<ContacInfo>(request); 
             await repository.CreateAsync(contactInfo);
             await unitOfWork.SaveChangesAsync();
             return BaseResult<object>.Success(contactInfo);
            throw new NotImplementedException();
        }
    }
}
