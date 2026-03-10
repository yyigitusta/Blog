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
    public class GetSocialByIdQueryHandler(IRepository<Social> repository , IMapper mapper) : IRequestHandler<GetSocialByIdQuery, BaseResult<GetSocialByIdQueryResult>>
    {
        public async Task<BaseResult<GetSocialByIdQueryResult>> Handle(GetSocialByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await repository.GetByIdAsync(request.id);
            if (value is null)
            {
                return BaseResult<GetSocialByIdQueryResult>.NotFound($"The social with id {request.id} was not found.");
            }
            var result = mapper.Map<GetSocialByIdQueryResult>(value);
            return BaseResult<GetSocialByIdQueryResult>.Success(result);
        }
    }
}
