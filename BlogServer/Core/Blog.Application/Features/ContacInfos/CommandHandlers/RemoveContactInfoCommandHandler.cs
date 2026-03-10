using Blog.Application.Contracts.Persistence;
using Blog.Application.Features.Base;
using Blog.Application.Features.ContacInfos.Command;
using Blog.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Features.ContacInfos.CommandHandlers
{
    public class RemoveContactInfoCommandHandler (IUnitOfWork unitOfWork , IRepository<ContacInfo> repository) : IRequestHandler<RemoveContacInfoCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(RemoveContacInfoCommand request, CancellationToken cancellationToken)
        {
                var contacinfo = await repository.GetByIdAsync(request.id);
                if (contacinfo is null)
                {
                    return BaseResult<object>.NotFound("ContacInfo not found");
            }
                repository.Delete(contacinfo);
                await unitOfWork.SaveChangesAsync();
                return BaseResult<object>.Success(contacinfo);
        }
    }
}
