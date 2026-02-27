using Blog.Application.Features.Base;
using Blog.Application.Features.Categories.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Features.Categories.Queries
{
    public record GetCategoryByIdQuery(Guid Id) : IRequest<BaseResult<GetCategoryByIdQueryResult>>;
    
}
