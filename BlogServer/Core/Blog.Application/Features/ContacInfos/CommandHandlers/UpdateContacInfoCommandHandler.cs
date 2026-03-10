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
    public class UpdateContacInfoCommandHandler(IRepository<ContacInfo> repository, IMapper mapper, IUnitOfWork unitOfWork)
        : IRequestHandler<UpdateContactInfoCommand, BaseResult<bool>>
    {
        public async Task<BaseResult<bool>> Handle(UpdateContactInfoCommand request, CancellationToken cancellationToken)
        {
            var result = mapper.Map<ContacInfo>(request);
            repository.Update(result);
            var response = await unitOfWork.SaveChangesAsync();

            return response
                ? BaseResult<bool>.Success(true)
                : BaseResult<bool>.Fail("Update işlemi başarısız.");
        }
    }
}
