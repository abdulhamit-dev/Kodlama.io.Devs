using Application.Features.Auth.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Entities;
using Core.Security.Enums;
using Core.Security.Hashing;
using Core.Security.JWT;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auth.Commands.Register
{
    public class RegisterUserCommand:IRequest<UserRegisterDto>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public class CreateUserCommandHandler : IRequestHandler<RegisterUserCommand, UserRegisterDto>
        {
            private readonly IUserRepository _userRepository;
            private readonly IMapper _mapper;
            private readonly ITokenHelper _tokenHelper;

            public CreateUserCommandHandler(IUserRepository userRepository, IMapper mapper, ITokenHelper tokenHelper)
            {
                _userRepository = userRepository;
                _mapper = mapper;
                _tokenHelper = tokenHelper;
            }

            public async Task<UserRegisterDto> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
            {
                byte[] _passwordHash, _passwordSalt;
                HashingHelper.CreatePasswordHash(request.Password, out _passwordHash, out _passwordSalt);
                User user = new()
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Email = request.Email,
                    PasswordHash = _passwordHash,
                    PasswordSalt = _passwordSalt,
                    Status = true,
                    AuthenticatorType = AuthenticatorType.Email
                };
                User createdUser = await _userRepository.AddAsync(user);
                List<OperationClaim> operationClaims = _userRepository.GetOperationClaims(createdUser).ToList();
                AccessToken accessToken = _tokenHelper.CreateToken(user, operationClaims);
                UserRegisterDto result = _mapper.Map<UserRegisterDto>(createdUser);
                result.AccessToken = accessToken;
                return result;
            }
        }
    }
}
