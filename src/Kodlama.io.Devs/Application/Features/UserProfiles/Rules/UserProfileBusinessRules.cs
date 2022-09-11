using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserProfiles.Rules
{
    public class UserProfileBusinessRules
    {
        private readonly IUserProfileRepository _userProfileRepository;

        public UserProfileBusinessRules(IUserProfileRepository userProfileRepository)
        {
            _userProfileRepository = userProfileRepository;
        }

        public async Task UserProfileGithubAdressCanNotBeDuplicatedWhenInserted(string githubAddress)
        {
            IPaginate<UserProfile> result = await _userProfileRepository.GetListAsync(b => b.GithubAddress == githubAddress);
            if (result.Items.Any())
                throw new BusinessException("UserProfile GithubAddress exists.");
        }
    }
}
