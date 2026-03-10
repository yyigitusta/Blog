using Blog.Application.Features.Base;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Features.ContacInfos.Command
{
    public class UpdateContactInfoCommand : IRequest<BaseResult<bool>>
    {
        public Guid Id { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string MapUrl { get; set; }
    }
}
