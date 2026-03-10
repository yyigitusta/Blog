using Blog.Application.Features.Messages.Command;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Features.Messages.Validator
{
    public class CreateMessageValidator : AbstractValidator<CreateMessageCommand>
    {
        public CreateMessageValidator()
        {
            RuleFor(x => x.FullName)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(100).WithMessage("Name must not exceed 100 characters.");
            RuleFor(x=>x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Subject is required.");
        }
    }
}
