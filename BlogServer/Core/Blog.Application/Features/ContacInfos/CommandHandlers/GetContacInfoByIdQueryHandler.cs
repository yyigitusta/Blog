using AutoMapper;
using Blog.Application.Contracts.Persistence;
using Blog.Application.Features.Base;
using Blog.Application.Features.Categories.Queries;
using Blog.Application.Features.Categories.Results;
using Blog.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Features.ContacInfos.CommandHandlers
{
    public class GetContacInfoByIdQueryHandler(IRepository<ContacInfo> repository , IMapper mapper) : IRequestHandler<GetCategoryByIdQuery, BaseResult<GetCategoryByIdQueryResult>>
    {
        public async Task<BaseResult<GetCategoryByIdQueryResult>> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
           var value = await repository.GetByIdAsync(request.Id);
            if (value is null)
            {
                return BaseResult<GetCategoryByIdQueryResult>.NotFound($"The category with id {request.Id} was not found.");
            }
            var result = mapper.Map<GetCategoryByIdQueryResult>(value);
            return BaseResult<GetCategoryByIdQueryResult>.Success(result);
        }
    }
}
