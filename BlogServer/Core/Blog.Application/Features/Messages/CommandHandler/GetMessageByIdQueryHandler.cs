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
    public class GetMessageByIdQueryHandler (IRepository<Message> repository , IMapper mapper) : IRequestHandler<GetMessageByIdQuery, BaseResult<GetMessageQueryByIdResult>>
    {
        public async Task<BaseResult<GetMessageQueryByIdResult>> Handle(GetMessageByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await repository.GetByIdAsync(request.id);
            
            var result = mapper.Map<GetMessageQueryByIdResult>(value);
            return BaseResult<GetMessageQueryByIdResult>.Success(result);
        }
    }
}
