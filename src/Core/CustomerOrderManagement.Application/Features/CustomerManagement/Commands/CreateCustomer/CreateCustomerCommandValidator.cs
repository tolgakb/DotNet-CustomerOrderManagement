﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrderManagement.Application.Features.CustomerManagement.Commands.CreateCustomer
{
    public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerCommandValidator()
        {
            RuleFor(c => c.FirstName)
                .NotEmpty().WithMessage("First name is required.")
                .MaximumLength(50).WithMessage("First name cannot exceed 50 characters");

            RuleFor(c => c.LastName)
               .NotEmpty().WithMessage("Last name is required.")
               .MaximumLength(50).WithMessage("Last name cannot exceed 50 characters.");

            RuleFor(c => c.Email)
                .NotEmpty().WithMessage("Email is required.")
                .MaximumLength(100).WithMessage("Email cannot exceed 100 characters.")
                .EmailAddress().WithMessage("Invalid email address.");

            RuleFor(c => c.Phone)
                .NotEmpty().WithMessage("Phone is required.")
                .MaximumLength(20).WithMessage("Phone cannot exceed 20 characters.");

            RuleFor(c => c.Address)
                .NotEmpty().WithMessage("Address is required.")
                .MaximumLength(500).WithMessage("Address cannot exceed 500 characters.")
                .MinimumLength(25).WithMessage("Address must be more than 25 characters.");

            RuleFor(c => c.City)
                .NotEmpty().WithMessage("City is required.")
                .MaximumLength(50).WithMessage("City cannot exceed 50 characters.");

            RuleFor(c => c.Country)
                .NotEmpty().WithMessage("Country is required.")
                .MaximumLength(50).WithMessage("Country cannot exceed 50 characters.");
        }
    }
}
