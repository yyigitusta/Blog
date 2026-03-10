using Blog.Application.Features.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Features.ContacInfos.Results
{
    public class GetContacInfoQueryResult : BaseDto
    {
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string MapUrl { get; set; }
    }
}
