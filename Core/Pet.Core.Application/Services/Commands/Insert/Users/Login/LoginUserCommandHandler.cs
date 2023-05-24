using AutoMapper;
using FluentValidation;
using MediatR;
using Pet.Core.Application.Repositories;
using Shared.Pet.Hashing;

namespace Pet.Core.Application.Services.Commands.Insert.Users.Login
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequestModel, LoginUserCommandResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<LoginUserCommandRequestModel> _validator;
        public LoginUserCommandHandler(IUserRepository userRepository, IMapper mapper, IValidator<LoginUserCommandRequestModel> validator)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<LoginUserCommandResponse> Handle(LoginUserCommandRequestModel request, CancellationToken cancellationToken)
        {

            var user = _userRepository.GetByFilter(u => u.Email == request.Email).FirstOrDefault();
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            bool isPasswordValid = PasswordHashing.VerifyPassword(request.Password, user.Password, user.PasswordSalt);
            var loginInfo = _mapper.Map<LoginUserCommandResponse>(user);
            return loginInfo;
        }
    }
}
