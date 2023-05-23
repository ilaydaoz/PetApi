using FluentValidation;
using Pet.Core.Application.Services.Commands.Insert.Users.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet.Core.Application.Validation.User
{
    public class LoginValidator : AbstractValidator<LoginUserCommandRequestModel>
    {
        public LoginValidator()
        {
            RuleFor(x => x.Password)
              .NotEmpty()
              .WithName("Şifre");

            RuleFor(x => x.Email)
             .NotEmpty()
             .WithName("Email");
        }
    }
}
