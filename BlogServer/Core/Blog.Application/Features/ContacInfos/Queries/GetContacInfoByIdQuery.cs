using Blog.Application.Features.Base;
using Blog.Application.Features.ContacInfos.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Features.ContacInfos.Queries
{
    public record GetContacInfoByIdQuery(Guid id) : IRequest<BaseResult<GetContacInfoByIdQueryResult>>
    {
    }
}
