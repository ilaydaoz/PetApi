using MediatR;

namespace Pet.Core.Application_.Services.Commands.Insert.Users.Register
{
    public class UserInsertCommandRequestModel : IRequest<UserInsertCommandResponse>
    {
        public string Name { get; set; }
        public string NickName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
