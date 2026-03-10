using Blog.Application.Features.Base;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Features.Socials.Commands
{
    public record DeleteSocialCommand(Guid id) : IRequest<BaseResult<object>>
    {
    }
}
