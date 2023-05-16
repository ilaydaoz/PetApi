using AutoMapper;
using Pet.Core.Domain.Entities;

namespace Pet.Core.Application_.Services.Commands.Insert.Users.Register
{
    public class UsertInsertCommandMapper : Profile
    {
        public UsertInsertCommandMapper()
        {
            CreateMap<UserInsertCommandRequestModel, User>();
            CreateMap<User, UserInsertCommandResponse>();
        }
    }
}
