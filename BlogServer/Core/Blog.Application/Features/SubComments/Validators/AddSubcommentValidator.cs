
using Blog.Application.Features.SubComments.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Features.SubComments.Validators
{
    public class AddSubcommentValidator : AbstractValidator<AddSubCommentCommand>
    {
        public AddSubcommentValidator()
        {
            RuleFor(x => x.Body)
                .NotEmpty().WithMessage("Subcomment body cannot be empty.")
                .MaximumLength(500).WithMessage("Subcomment body cannot exceed 500 characters.");
            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("User ID is required.");
            RuleFor(x => x.CommentId).NotEmpty().WithMessage("Comment ID is required.");

        }
    }
}
