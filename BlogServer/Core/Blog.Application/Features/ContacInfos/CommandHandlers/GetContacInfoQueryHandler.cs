using AutoMapper;
using Blog.Application.Contracts.Persistence;
using Blog.Application.Features.Base;
using Blog.Application.Features.ContacInfos.Queries;
using Blog.Application.Features.ContacInfos.Results;
using Blog.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Features.ContacInfos.CommandHandlers
{
    public class GetContacInfoQueryHandler (IRepository<ContacInfo> repository , IMapper mapper) : IRequestHandler<GetContacInfoQuery, BaseResult<List<GetContacInfoQueryResult>>>
    {
        public async Task<BaseResult<List<GetContacInfoQueryResult>>> Handle(GetContacInfoQuery request, CancellationToken cancellationToken)
        {
            var contacInfos = await repository.GetAllAsync();
            if (contacInfos == null || !contacInfos.Any())
            {
                return BaseResult<List<GetContacInfoQueryResult>>.NotFound("No contact information found.");
            }
            var result = mapper.Map<List<GetContacInfoQueryResult>>(contacInfos);
            return  BaseResult<List<GetContacInfoQueryResult>>.Success(result)   ;
        }
    }
}
