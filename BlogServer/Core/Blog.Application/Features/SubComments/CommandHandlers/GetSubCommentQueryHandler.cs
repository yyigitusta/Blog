using AutoMapper;
using Blog.Application.Contracts.Persistence;
using Blog.Application.Features.Base;
using Blog.Application.Features.Blogs.Result;
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
    public class GetSubCommentQueryHandler(IRepository<SubComment> repository , IMapper mapper) : IRequestHandler<GetSubCommentQuery, BaseResult<List<GetSubCommentsQueryResult>>>
    {
        public async Task<BaseResult<List<GetSubCommentsQueryResult>>> Handle(GetSubCommentQuery request, CancellationToken cancellationToken)
        {
            var comment = await repository.GetAllAsync();
            var subcomments = mapper.Map<List<GetSubCommentsQueryResult>>(comment);
            return BaseResult<List<GetSubCommentsQueryResult>>.Success(subcomments);

        }
    }
}
