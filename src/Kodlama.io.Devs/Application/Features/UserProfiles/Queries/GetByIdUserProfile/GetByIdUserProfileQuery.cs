using Application.Features.UserProfiles.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserProfiles.Queries.GetByIdUserProfile
{
    public class GetByIdUserProfileQuery:IRequest<UserProfileGetByIdDto>
    {
        public int Id { get; set; }
        public class GetByIdUserProfileQueryHandler : IRequestHandler<GetByIdUserProfileQuery, UserProfileGetByIdDto>
        {
            private readonly IUserProfileRepository _userProfileRepository;
            private readonly IMapper _mapper;

            public GetByIdUserProfileQueryHandler(IUserProfileRepository userProfileRepository, IMapper mapper)
            {
                _userProfileRepository = userProfileRepository;
                _mapper = mapper;
            }

            public async Task<UserProfileGetByIdDto> Handle(GetByIdUserProfileQuery request, CancellationToken cancellationToken)
            {
                UserProfile userProfile = await _userProfileRepository.GetAsync(x => x.UserId == request.Id);

                UserProfileGetByIdDto userProfileGetByIdDto=_mapper.Map<UserProfileGetByIdDto>(userProfile);

                return userProfileGetByIdDto;
            }
        }
    }
}
