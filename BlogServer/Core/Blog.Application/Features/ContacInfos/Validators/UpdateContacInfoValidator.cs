using Blog.Application.Features.ContacInfos.Command;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Features.ContacInfos.Validators
{
    public class UpdateContacInfoValidator :AbstractValidator<UpdateContactInfoCommand>
    {
        public UpdateContacInfoValidator()
        {
            RuleFor(x => x.Email).NotEmpty().EmailAddress().WithMessage("A valid email address is required.");
            RuleFor(x => x.Phone).NotEmpty().WithMessage("Phone number is required.")
                .Matches(@"^\+?[1-9]\d{1,14}$").WithMessage("A valid phone number is required.");
            RuleFor(x => x.Address).NotEmpty().WithMessage("Address is required.");
        }
    }
}
