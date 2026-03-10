using AutoMapper;
using Blog.Application.Contracts.Persistence;
using Blog.Application.Features.Base;
using Blog.Application.Features.Socials.Commands;
using Blog.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Features.Socials.CommandHandlers
{
    public class DeleteSocialCommandHandler(IRepository<Social> repository , IUnitOfWork unitOfWork , IMapper mapper) : IRequestHandler<DeleteSocialCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(DeleteSocialCommand request, CancellationToken cancellationToken)
        {
            var social= await repository.GetByIdAsync(request.id);
            var sociall=mapper.Map<Social>(social);
            repository.Delete(sociall);  
            await unitOfWork.SaveChangesAsync();
            return BaseResult<object>.Success(sociall);
        }
    }
}
