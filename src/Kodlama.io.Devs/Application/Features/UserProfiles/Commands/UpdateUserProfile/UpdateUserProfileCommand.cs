using Application.Features.UserProfiles.Dtos;
using Application.Features.UserProfiles.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserProfiles.Commands.UpdateUserProfile
{
    public class UpdateUserProfileCommand:IRequest<UpdatedUserProfileDto>
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string GithubAddress { get; set; }
        public class UpdateUserProfileCommandHandler : IRequestHandler<UpdateUserProfileCommand, UpdatedUserProfileDto>
        {
            private readonly IUserProfileRepository _userProfileRepository;
            private readonly IMapper _mapper;
            private readonly UserProfileBusinessRules _userProfileBusinessRules;

            public UpdateUserProfileCommandHandler(IUserProfileRepository userProfileRepository, IMapper mapper, UserProfileBusinessRules userProfileBusinessRules)
            {
                _userProfileRepository = userProfileRepository;
                _mapper = mapper;
                _userProfileBusinessRules = userProfileBusinessRules;
            }

            public async Task<UpdatedUserProfileDto> Handle(UpdateUserProfileCommand request, CancellationToken cancellationToken)
            {
                await _userProfileBusinessRules.UserProfileGithubAdressCanNotBeDuplicatedWhenInserted(request.GithubAddress);

                UserProfile mappedUserProfile = _mapper.Map<UserProfile>(request);
                UserProfile userProfile= await _userProfileRepository.UpdateAsync(mappedUserProfile);
                UpdatedUserProfileDto UpdatedUserProfileDto = _mapper.Map<UpdatedUserProfileDto>(userProfile);

                return UpdatedUserProfileDto;
            }
        }
    }
}
