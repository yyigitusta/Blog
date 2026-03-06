using AutoMapper;
using Blog.Application.Contracts.Persistence;
using Blog.Application.Features.Base;
using Blog.Application.Features.Blogs.Commands;
using Blog.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Features.Blogs.Handlers
{
    public class CreateBlogCommandHandler(IRepository<eBlog> repository,IMapper mapper, IUnitOfWork unitOfWork) : IRequestHandler<CreateBlogCommand, BaseResult<object>>
    {
        public  async Task<BaseResult<object>> Handle(CreateBlogCommand request, CancellationToken cancellationToken)
        {
            var blog = mapper.Map<eBlog>(request);
            await repository.CreateAsync(blog);
            await unitOfWork.SaveChangesAsync();
            return BaseResult<object>.Success(blog);
        }
    }
}
