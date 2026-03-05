using Blog.Application.Features.Users.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Features.Users.Validator
{
    public class CreateUserValidator : AbstractValidator<CreateUserCommand>   
    {
        public CreateUserValidator()
        {
            RuleFor(x=>x.FirstName).NotEmpty().WithMessage("FirstName is required.")
                .MinimumLength(2).WithMessage("FirstName must be at least 2 characters.");
            RuleFor(x=>x.LastName).NotEmpty().WithMessage("LastName is required.")
                .MinimumLength(2).WithMessage("LastName must be at least 2 characters.");
            RuleFor(x=>x.UserName).NotEmpty().WithMessage("UserName is required.")
                .MinimumLength(3).WithMessage("UserName must be at least 3 characters.");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required.").EmailAddress().WithMessage("Email is not valid");
            RuleFor(x=>x.Password).NotEmpty().WithMessage("Password is required.")
                .MinimumLength(6).WithMessage("Password must be at least 6 characters.");
        }
    }
}
