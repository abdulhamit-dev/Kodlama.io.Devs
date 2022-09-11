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

namespace Application.Features.UserProfiles.Commands.DeleteUserProfile
{
    public class DeleteUserProfileCommand:IRequest<DeletedUserProfileDto>
    {
        public int Id { get; set; }
        public class DeleteUserProfileCommandHandler : IRequestHandler<DeleteUserProfileCommand, DeletedUserProfileDto>
        {
            private readonly IUserProfileRepository _userProfileRepository;
            private readonly IMapper _mapper;

            public DeleteUserProfileCommandHandler(IUserProfileRepository userProfileRepository, IMapper mapper)
            {
                _userProfileRepository = userProfileRepository;
                _mapper = mapper;
            }

            public async Task<DeletedUserProfileDto> Handle(DeleteUserProfileCommand request, CancellationToken cancellationToken)
            {
                UserProfile mappedUserProfile = _mapper.Map<UserProfile>(request);
                UserProfile userProfile = await _userProfileRepository.DeleteAsync(mappedUserProfile);
                DeletedUserProfileDto DeletedUserProfileDto = _mapper.Map<DeletedUserProfileDto>(userProfile);

                return DeletedUserProfileDto;
            }
        }
    }
}
