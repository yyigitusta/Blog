using Blog.Application.Features.Base;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Blog.Application.Features.Comments.Commands
{
    public record UpdateCommentCommand : IRequest<BaseResult<object>>
    {
        public Guid Id { get; init; }
        public string UserId { get; init; }
        public string Body { get; init; }
        
        public Guid BlogId { get; init; }
    }
}
