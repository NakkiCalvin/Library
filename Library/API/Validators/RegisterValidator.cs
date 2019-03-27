using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Requests;
using BLL.Managers;
using FluentValidation;

namespace API.Validators
{
    public class RegisterValidator : AbstractValidator<RegisterUserModel>
    {
        public RegisterValidator(IUserManager userManager, ISignInManager signInManager)
        {
            RuleFor(x => x.Email).EmailAddress().NotEmpty().WithMessage($"Current email is invalid.");

            RuleFor(x => x.Password).NotNull().MinimumLength(6).MaximumLength(20);
        }
    }
}
