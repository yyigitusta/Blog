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
    public class UpdateBlogCommandHandler(IRepository<eBlog> repository,IMapper mapper,IUnitOfWork unitOfWork) : IRequestHandler<UpdateBlogCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
        {
            var blog = mapper.Map<eBlog>(request);
            repository.Update(blog);
            var response = await unitOfWork.SaveChangesAsync();
            return response ? BaseResult<object>.Success(response) : BaseResult<object>.Fail("Failed to update the blog.");
        }
    }
}
