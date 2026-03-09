using Blog.Application.Features.Base;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Blog.Application.Features.SubComments.Commands
{
    public class UpdateSubCommentCommand : IRequest<BaseResult<object>>
    {
        public Guid id { get; init; }
        public string UserId { get; init; }
        public string Body { get; init; }
        [JsonIgnore]
        public DateTime CommentDate { get; init; } = DateTime.UtcNow;
        public Guid CommentId { get; init; }
    }
}
