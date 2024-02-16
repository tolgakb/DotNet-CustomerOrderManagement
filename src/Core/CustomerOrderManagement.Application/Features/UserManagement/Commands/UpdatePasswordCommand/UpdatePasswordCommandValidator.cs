using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrderManagement.Application.Features.UserManagement.Commands.UpdatePasswordCommand
{
    public class UpdatePasswordCommandValidator : AbstractValidator<UpdatePasswordCommand>
    {
        public UpdatePasswordCommandValidator()
        {
            RuleFor(v => v.UserId)
               .NotEmpty();

            RuleFor(v => v.OldPassword)
                .MaximumLength(255)
                .NotEmpty();

            RuleFor(v => v.NewPassword)
                .MaximumLength(255)
                .NotEmpty();
        }

    }
}
