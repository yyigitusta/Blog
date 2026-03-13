using AutoMapper;
using Blog.Application.Contracts.Persistence;
using Blog.Application.Features.Base;
using Blog.Application.Features.Users.Quaries;
using Blog.Application.Features.Users.Results;
using Blog.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Features.Users.Handlers
{
    public class GetLoginQueryHandler(UserManager<AppUser> userManager , IJwtService jwtService , IMapper mapper) : IRequestHandler<GetLoginQuery, BaseResult<GetLoginResponse>>
    {
        public async Task<BaseResult<GetLoginResponse>> Handle(GetLoginQuery request, CancellationToken cancellationToken)
        {
            var user = await userManager.FindByEmailAsync(request.Email);
            if(user is null) {return BaseResult<GetLoginResponse>.Fail("User not found"); }
            var result = await userManager.CheckPasswordAsync(user,request.Password);
            if (!result) { return BaseResult<GetLoginResponse>.Fail("InCorrect Password"); };
            var userResult = mapper.Map<GetUserQueryResult>(user);
            var response = await jwtService.GenerateTokenAsync(userResult);
            if(response is null) { return BaseResult<GetLoginResponse>.Fail("Token couldnt be generated"); }
            return BaseResult<GetLoginResponse>.Success(response);
        }
    }
}
