using FluentValidation;
using Pet.Core.Application.Services.Commands.Insert.Users.Register;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet.Core.Application.Validation.User
{
    public class InsertRegistrationValidator : AbstractValidator<UserInsertCommandRequestModel>
    {
        public InsertRegistrationValidator()
        {
            RuleFor(x => x.Name)
              .NotEmpty()
              .MinimumLength(3)
              .MaximumLength(50)
              .WithName("İsim");

            RuleFor(x => x.NickName)
               .NotEmpty()
               .MinimumLength(3)
               .MaximumLength(50)
               .WithName("Kullanıcı Adı");

            RuleFor(x => x.Email)
               .NotEmpty()
               .WithName("Email");

            RuleFor(x => x.Password)
               .NotEmpty()
               .MinimumLength(3)
               .MaximumLength(50)
               .WithName("Şifre");  
        }
    }
}
