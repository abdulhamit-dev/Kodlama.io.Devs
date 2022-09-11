using Application.Features.Auth.Dtos;
using Application.Features.Auth.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Entities;
using Core.Security.JWT;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auth.Queries.Login
{
    public class LoginUserQuery: IRequest<UserLoginDto>
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public class LoginUserQueryHandler : IRequestHandler<LoginUserQuery, UserLoginDto>
        {
            private readonly IUserRepository _userRepository;
            private readonly IMapper _mapper;
            private readonly ITokenHelper _tokenHelper;
            private readonly AuthBusinessRules _authBusinessRules;

            public LoginUserQueryHandler(IUserRepository userRepository, IMapper mapper, ITokenHelper tokenHelper, AuthBusinessRules authBusinessRules)
            {
                _userRepository = userRepository;
                _mapper = mapper;
                _tokenHelper = tokenHelper;
                _authBusinessRules = authBusinessRules;
            }

            public async Task<UserLoginDto> Handle(LoginUserQuery request, CancellationToken cancellationToken)
            {
                User? user = await _userRepository.GetAsync(x => x.Email == request.Email);
                await _authBusinessRules.UserShouldBeExistWhenLoggedIn(user);
                await _authBusinessRules.UserCredentialsShouldBeMatchWhenLoggedIn(user, request.Password);
                IList<OperationClaim> operationClaims = _userRepository.GetOperationClaims(user!);
                AccessToken token = _tokenHelper.CreateToken(user!, operationClaims);
                UserLoginDto userLoginDto = _mapper.Map<UserLoginDto>(token);
                return userLoginDto;
            }
        }
    }
}
