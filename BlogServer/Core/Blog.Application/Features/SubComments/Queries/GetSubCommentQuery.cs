using Blog.Application.Features.Base;
using Blog.Application.Features.SubComments.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Features.SubComments.Queries
{
    public record GetSubCommentQuery : IRequest<BaseResult<List<GetSubCommentsQueryResult>>>
    {
    }
}
