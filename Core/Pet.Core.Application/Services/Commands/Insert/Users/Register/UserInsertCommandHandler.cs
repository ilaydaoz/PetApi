using AutoMapper;
using MediatR;
using Pet.Core.Application_.Repositories;
using Pet.Core.Domain.Entities;

namespace Pet.Core.Application_.Services.Commands.Insert.Users.Register
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
            var user = _mapper.Map<User>(request);
            var userAdd = await _userRepository.InsertAsync(user);
            await _userRepository.SaveAsync();
            var userMap = _mapper.Map<UserInsertCommandResponse>(userAdd);
            return userMap;
        }
    }
}
