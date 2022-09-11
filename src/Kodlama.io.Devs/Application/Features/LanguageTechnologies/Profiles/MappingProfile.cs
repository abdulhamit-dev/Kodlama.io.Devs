using Application.Features.LanguageTechnologies.Commands;
using Application.Features.LanguageTechnologies.Dtos;
using Application.Features.LanguageTechnologies.Models;
using Application.Features.ProgrammingLanguages.Commands.CreateProgramingLanguage;
using Application.Features.ProgrammingLanguages.Commands.DeleteProgrammingLanguage;
using Application.Features.ProgrammingLanguages.Dtos;
using Application.Features.ProgrammingLanguages.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.LanguageTechnologies.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<LanguageTechnology, CreatedLanguageTechnologyDto>().ReverseMap();
            CreateMap<LanguageTechnology, CreateLanguageTechnologyCommand>().ReverseMap();

            CreateMap<LanguageTechnology, UpdatedLanguageTechnologyDto>().ReverseMap();
            CreateMap<LanguageTechnology, UpdateLanguageTechnologyCommand>().ReverseMap();

            CreateMap<LanguageTechnology, DeletedLanguageTechnologyDto>().ReverseMap();
            CreateMap<LanguageTechnology, DeleteLanguageTechnologyCommand>().ReverseMap();

            CreateMap<LanguageTechnology, LanguageTechnologyListDto>().ForMember(c => c.ProgrammingLanguageName, opt => opt.MapFrom(c => c.ProgrammingLanguage.Name))
                .ReverseMap();

            CreateMap<IPaginate<LanguageTechnology>, LanguageTechnologyListModel>().ReverseMap();


        }
    }
}
