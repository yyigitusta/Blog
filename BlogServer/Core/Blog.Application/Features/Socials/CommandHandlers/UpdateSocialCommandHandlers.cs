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
    public class UpdateSocialCommandHandlers(IRepository<Social> repository , IUnitOfWork unitOfWork ,Mapper mapper ) : IRequestHandler<UpdateSocialCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(UpdateSocialCommand request, CancellationToken cancellationToken)
        {
            var social = await repository.GetByIdAsync(request.Id);
            var mappedSocial = mapper.Map<Social>(social);
            repository.Update(mappedSocial);
            await unitOfWork.SaveChangesAsync();
            return BaseResult<object>.Success(mappedSocial);
        }
    }
}
