using Blog.Application.Features.Base;
using Blog.Application.Features.Comments.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Features.Comments.Queries
{
    public record GetCommentByIdQuery(Guid Id) : IRequest<BaseResult<GetCommentByIdQueryResult>>
    {
    }
}
