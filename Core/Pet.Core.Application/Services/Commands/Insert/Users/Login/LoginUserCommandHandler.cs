using AutoMapper;
using MediatR;
using Pet.Core.Application.Repositories;
using Shared.Pet.Hashing;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Pet.Core.Application.Services.Commands.Insert.Users.Login
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequestModel, LoginUserCommandResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public LoginUserCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<LoginUserCommandResponse> Handle(LoginUserCommandRequestModel request, CancellationToken cancellationToken)
        {
            var user = _userRepository.GetByFilter(u => u.Email == request.Email).FirstOrDefault();
            bool isPasswordValid = PasswordHashing.VerifyPassword(request.Password, user.Password, user.PasswordSalt);
            var loginInfo = _mapper.Map<LoginUserCommandResponse>(user);
            return loginInfo;
        }
    }
}
