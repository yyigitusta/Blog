using AutoMapper;
using Blog.Application.Contracts.Persistence;
using Blog.Application.Features.Base;
using Blog.Application.Features.Socials.Queries;
using Blog.Application.Features.Socials.Results;
using Blog.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Features.Socials.CommandHandlers
{
    public class GetSocialQueryHandler(IMapper mapper , IRepository<Social> repository) : IRequestHandler<GetSocialQuery, BaseResult<List<GetSocialQueryResult>>>
    {
        public async Task<BaseResult<List<GetSocialQueryResult>>> Handle(GetSocialQuery request, CancellationToken cancellationToken)
        {
            var socials = await repository.GetAllAsync();
            var result = mapper.Map<List<GetSocialQueryResult>>(socials);
            return BaseResult<List<GetSocialQueryResult>>.Success(result);
        }
    }
}
