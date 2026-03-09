using AutoMapper;
using Blog.Application.Contracts.Persistence;
using Blog.Application.Features.Base;
using Blog.Application.Features.Blogs.Result;
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
    public class GetCommentsQueryHandler(IRepository<Comment> repository,IMapper mapper) :
        IRequestHandler<GetCommentsQuery, BaseResult<List<GetCommentsQueryResult>>>
    {
        public async Task<BaseResult<List<GetCommentsQueryResult>>> Handle(GetCommentsQuery request, CancellationToken cancellationToken)
        {
            var comments = await repository.GetAllAsync();
            var result = mapper.Map<List<GetCommentsQueryResult>>(comments);
            return BaseResult<List<GetCommentsQueryResult>>.Success(result);
        }

       
    }
}
