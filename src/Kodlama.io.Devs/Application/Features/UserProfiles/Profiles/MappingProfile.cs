using Application.Features.UserProfiles.Commands.CreateUserProfile;
using Application.Features.UserProfiles.Commands.DeleteUserProfile;
using Application.Features.UserProfiles.Commands.UpdateUserProfile;
using Application.Features.UserProfiles.Dtos;
using Application.Features.UserProfiles.Queries.GetByIdUserProfile;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.UserProfiles.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserProfile, CreatedUserProfileDto>().ReverseMap();
            CreateMap<UserProfile, CreateUserProfileCommand>().ReverseMap();

            CreateMap<UserProfile, UpdatedUserProfileDto>().ReverseMap();
            CreateMap<UserProfile, UpdateUserProfileCommand>().ReverseMap();

            CreateMap<UserProfile, DeleteUserProfileCommand>().ReverseMap();
            CreateMap<UserProfile, DeletedUserProfileDto>().ReverseMap();

            CreateMap<UserProfile, UserProfileGetByIdDto>().ReverseMap();
            CreateMap<UserProfile, GetByIdUserProfileQuery>().ReverseMap();


        }
    }
}
