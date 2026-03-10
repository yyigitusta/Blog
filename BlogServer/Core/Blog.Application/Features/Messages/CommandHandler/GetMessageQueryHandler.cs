using AutoMapper;
using Blog.Application.Contracts.Persistence;
using Blog.Application.Features.Base;
using Blog.Application.Features.Messages.Queries;
using Blog.Application.Features.Messages.Results;
using Blog.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Features.Messages.CommandHandler
{
    public class GetMessageQueryHandler(IRepository<Comment> repository , IMapper mapper) : IRequestHandler<GetMessageQuery, BaseResult<List<GetMessageQueryResult>>>
    {
        public async Task<BaseResult<List<GetMessageQueryResult>>> Handle(GetMessageQuery request, CancellationToken cancellationToken)
        {
            var comments = await repository.GetAllAsync();
                var commentsResult = mapper.Map<List<GetMessageQueryResult>>(comments);

            return BaseResult<List<GetMessageQueryResult>>.Success(commentsResult);
        }
    }
}
