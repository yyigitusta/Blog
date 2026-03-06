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
    public class RemoveBlogCommandHandler(IRepository<eBlog> repository , IUnitOfWork unitOfWork) : 
        IRequestHandler<RemoveBlogCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(RemoveBlogCommand request, CancellationToken cancellationToken)
        {
            var blog = await repository.GetByIdAsync(request.Id);
            if (blog == null)
            {
                return BaseResult<object>.NotFound("Blog not found");
            }
            repository.Delete(blog);
            var result = await unitOfWork.SaveChangesAsync();
            return result ? BaseResult<object>.Success("Blog has been deleted succesfuly") : BaseResult<object>.Fail("Failed to delete the blog");
        }
    }
}
