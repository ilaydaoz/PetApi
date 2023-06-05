using AutoMapper;
using FluentValidation;
using MediatR;
using Pet.Core.Application.Repositories;
using Pet.Core.Domain.Entities;
using Shared.Pet.Hashing;
using Shared.Pet.Middleware;

namespace Pet.Core.Application.Services.Commands.Insert.Users.Register
{
    public class UserInsertCommandHandler : IRequestHandler<UserInsertCommandRequestModel, UserInsertCommandResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<UserInsertCommandRequestModel> _validator;
        private readonly JWTAuthenticationMiddleware _jwtAuthenticationMiddleware;

        public UserInsertCommandHandler(IUserRepository userRepository, IMapper mapper, IValidator<UserInsertCommandRequestModel> validator, JWTAuthenticationMiddleware jwtAuthenticationMiddleware)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _validator = validator;
            _jwtAuthenticationMiddleware = jwtAuthenticationMiddleware;
        }

        public async Task<UserInsertCommandResponse> Handle(UserInsertCommandRequestModel request, CancellationToken cancellationToken)
        {
            string salt;
            string hashedPassword = PasswordHashing.HashingHelper(request.Password, out salt);
            var user = _mapper.Map<User>(request);
            user.Password = hashedPassword;
            user.PasswordSalt = salt;
            var userAdd = await _userRepository.InsertAsync(user);

            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

           
            var userMap = _mapper.Map<UserInsertCommandResponse>(userAdd);

            
            string token = _jwtAuthenticationMiddleware.GenerateJwtToken(user.Id.ToString(), user.Name);
            userMap.Token = token;
 await _userRepository.SaveAsync();
            return userMap;
        }
    }

}
