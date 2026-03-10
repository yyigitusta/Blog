using Blog.Application.Features.Base;
using Blog.Application.Features.Messages.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Features.Messages.Queries
{
    public class GetMessageQuery : IRequest<BaseResult<List<GetMessageQueryResult>>>
    {
    }
}
