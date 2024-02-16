using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrderManagement.Application.Features.Authentication.Commands.AuthUserCommand
{
    public class AuthUserCommandValidator : AbstractValidator<AuthUserCommand>
    {
        public AuthUserCommandValidator()
        {
            RuleFor(v => v.UserName)
                .NotEmpty();

            RuleFor(v => v.Password)
                .NotEmpty();
        }
    }
}
