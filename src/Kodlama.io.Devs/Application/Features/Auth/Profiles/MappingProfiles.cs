using Application.Features.Auth.Commands.Register;
using Application.Features.Auth.Dtos;
using Application.Features.Auth.Queries.Login;
using AutoMapper;
using Core.Security.Entities;
using Core.Security.JWT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auth.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<User, UserRegisterDto>().ReverseMap();
            CreateMap<User, RegisterUserCommand>().ReverseMap();

            CreateMap<User, LoginUserQuery>().ReverseMap();
            CreateMap<AccessToken, UserLoginDto>().ReverseMap();
        }
    }
}
