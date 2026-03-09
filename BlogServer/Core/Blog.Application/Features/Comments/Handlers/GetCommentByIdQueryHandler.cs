using AutoMapper;
using Blog.Application.Contracts.Persistence;
using Blog.Application.Features.Base;
using Blog.Application.Features.Comments.Queries;
using Blog.Application.Features.Comments.Results;
using Blog.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Features.Comments.Handlers
{
    public class GetCommentByIdQueryHandler(IMapper mapper, IRepository<Comment> repository) : IRequestHandler<GetCommentByIdQuery, BaseResult<GetCommentByIdQueryResult>>
    {
        public async Task<BaseResult<GetCommentByIdQueryResult>> Handle(GetCommentByIdQuery request, CancellationToken cancellationToken)
        {
            var comment = await repository.GetByIdAsync(request.Id);
            if (comment is null)
            {
                return BaseResult<GetCommentByIdQueryResult>.NotFound("Comment id not found.");
            }
            var result = mapper.Map<GetCommentByIdQueryResult>(comment);
            return BaseResult<GetCommentByIdQueryResult>.Success(result);
        }
    }
}
