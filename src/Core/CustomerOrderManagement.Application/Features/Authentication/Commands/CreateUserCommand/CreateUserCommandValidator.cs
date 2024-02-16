using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrderManagement.Application.Features.Authentication.Commands.CreateUserCommand
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(v => v.FullName)
                .NotEmpty();

            RuleFor(v => v.Email)
                .NotEmpty();

            RuleFor(v => v.UserName)
                .NotEmpty();

            RuleFor(v => v.Password)
                .NotEmpty();
        }
    }
}
