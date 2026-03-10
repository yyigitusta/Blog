using Blog.Application.Features.Base;
using Blog.Application.Features.Socials.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Features.Socials.Queries
{
    public class GetSocialQuery : IRequest<BaseResult<List<GetSocialQueryResult>>>
    {
    }
}
