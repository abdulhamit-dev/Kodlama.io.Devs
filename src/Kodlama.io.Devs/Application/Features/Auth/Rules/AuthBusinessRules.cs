using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;
using Core.Security.Hashing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auth.Rules
{
    public class AuthBusinessRules
    {
        private readonly IUserRepository _userRepository;

        public AuthBusinessRules(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        public async Task UserShouldBeExistWhenLoggedIn(User? user)
        {
            if (user == null) throw new BusinessException("Requested user does not exist.");
        }

        public async Task UserCredentialsShouldBeMatchWhenLoggedIn(User user, string password)
        {
            bool isUserPasswordNotVerified = !HashingHelper.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt);
            if (isUserPasswordNotVerified) throw new BusinessException("User credentials does not match.");
        }
    }
}
