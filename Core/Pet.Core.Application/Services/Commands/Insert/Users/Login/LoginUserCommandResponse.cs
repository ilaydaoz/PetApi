using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet.Core.Application.Services.Commands.Insert.Users.Login
{
    public class LoginUserCommandResponse
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
