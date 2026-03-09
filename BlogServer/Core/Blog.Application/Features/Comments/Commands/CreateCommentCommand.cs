using Blog.Application.Features.Base;
using MediatR;
using System.Text.Json.Serialization;

namespace Blog.Application.Features.Comments.Commands
{
    public record CreateCommentCommand : IRequest<BaseResult<object>>
    {
        public string UserId { get; init; }
        public string Body { get; init; }
        [JsonIgnore]
        public DateTime CommentDate =DateTime.UtcNow;
        public Guid BlogId { get; init; }
    }
}
