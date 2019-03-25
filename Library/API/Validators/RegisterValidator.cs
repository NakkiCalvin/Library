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
        public RegisterValidator(IUserManager userManager)
        {
            RuleFor(x => x.Email).EmailAddress().NotEmpty().MustAsync(async (model, email, context) =>
                {
                    var userResult = await userManager.GetUserByEmail(email);
                    return userResult == null;
                })
                .WithMessage($"Current email is already taken.");

            //RuleFor(x => x.Password).NotNull().MinimumLength(5).MaximumLength(20);
        }
    }
}
