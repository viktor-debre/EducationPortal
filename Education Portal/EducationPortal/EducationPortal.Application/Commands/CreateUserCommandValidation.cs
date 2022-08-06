﻿using EducationPortal.Domain.Entities;
using FluentValidation;
using System.Text.RegularExpressions;

namespace EducationPortal.Application.Commands
{
    internal class CreateUserCommandValidation : AbstractValidator<User>
    {
        public CreateUserCommandValidation()
        {
            RuleFor(u => u.Name)
                .NotEmpty()
                .MaximumLength(200);

            RuleFor(u => u.Password)
                .NotEmpty()
                .MinimumLength(4)
                .Must(IsValidPassword);
        }

        private bool IsValidPassword(string password)
        {
            Regex validateGuidRegex = new Regex("^(?=.*?[0-9])$");
            if (!validateGuidRegex.IsMatch(password))
            {
                return false;
            }
            return true;
        }
    }
}
