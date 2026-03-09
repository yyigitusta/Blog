using AutoMapper;
using Blog.Application.Contracts.Persistence;
using Blog.Application.Features.Base;
using Blog.Application.Features.SubComments.Queries;
using Blog.Application.Features.SubComments.Results;
using Blog.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Features.SubComments.CommandHandlers
{
    public class GetSubCommentQueryByIdHandler (IRepository<SubComment> repository , IMapper mapper) : IRequestHandler<GetSubCommentByIdQuery, BaseResult<GetSubCommentByIdResult>>
    {
        public async Task<BaseResult<GetSubCommentByIdResult>> Handle(GetSubCommentByIdQuery request, CancellationToken cancellationToken)
        {
            var subComment = await repository.GetByIdAsync(request.id);
            if (subComment == null)
            {
                return BaseResult<GetSubCommentByIdResult>.Fail("SubComment not found");
            }
            var result = mapper.Map<GetSubCommentByIdResult>(subComment);
            return BaseResult<GetSubCommentByIdResult>.Success(result);
        }
    }
}
