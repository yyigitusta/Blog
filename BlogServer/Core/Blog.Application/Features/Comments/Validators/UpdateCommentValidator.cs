using Blog.Application.Features.Comments.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Features.Comments.Validators
{
    public class UpdateCommentValidator : AbstractValidator<UpdateCommentCommand>
    {
        public UpdateCommentValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Comment Id is required.");
            RuleFor(x => x.Body).NotEmpty().WithMessage("Comment body is required.");
            RuleFor(x => x.UserId).NotEmpty().WithMessage("User Id is required.");
            RuleFor(x => x.BlogId).NotEmpty().WithMessage("Blog Id is required.");
        }
    }
}
