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
    public class CreateSocialCommandHandler(IRepository<Social> repository , IUnitOfWork unitOfWork , IMapper mapper) : IRequestHandler<CreateSocialCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(CreateSocialCommand request, CancellationToken cancellationToken)
        {
            var social= mapper.Map<Social>(request);
            await repository.CreateAsync(social);
            await unitOfWork.SaveChangesAsync();
            return BaseResult<object>.Success(social);
        }
    }
}
