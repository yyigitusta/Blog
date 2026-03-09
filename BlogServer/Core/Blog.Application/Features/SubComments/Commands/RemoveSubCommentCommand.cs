using Blog.Application.Features.Base;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Features.SubComments.Commands
{
    public record RemoveSubCommentCommand(Guid subCommentId) : IRequest<BaseResult<object>>
    {
    }
}
