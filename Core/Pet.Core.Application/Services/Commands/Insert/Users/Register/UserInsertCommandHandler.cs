using AutoMapper;
using MediatR;
using Pet.Core.Application.Repositories;
using Pet.Core.Domain.Entities;
using Shared.Pet.Hashing;

namespace Pet.Core.Application.Services.Commands.Insert.Users.Register
{
    public class UserInsertCommandHandler : IRequestHandler<UserInsertCommandRequestModel, UserInsertCommandResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserInsertCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<UserInsertCommandResponse> Handle(UserInsertCommandRequestModel request, CancellationToken cancellationToken)
        {
            string hashedPassword = PasswordHashing.HashingHelper(request.Password, out string salt);
            var user = _mapper.Map<User>(request);
            user.Password = hashedPassword;
            var userAdd = await _userRepository.InsertAsync(user);
            await _userRepository.SaveAsync();
            var userMap = _mapper.Map<UserInsertCommandResponse>(userAdd);
            return userMap;
        }
    }
}
