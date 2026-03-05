using AutoMapper;
using Blog.Application.Features.Base;
using Blog.Application.Features.Users.Commands;
using Blog.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Blog.Application.Features.Users.Handlers
{
    public class CreateUserCommandHandler(UserManager<AppUser> _userManager,IMapper mapper) : IRequestHandler<CreateUserCommand, BaseResult<object>>
    {
        public async Task<BaseResult<object>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new AppUser
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                UserName = request.UserName
            };


            var result = _userManager.CreateAsync(user, request.Password);
            if (!result.Result.Succeeded)
            {
                return BaseResult<object>.Fail(result.Result.Errors.Select(e => e.Description));    
            }
            return BaseResult<object>.Success("User is created succesfly");
        }
    }
}
