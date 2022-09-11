using Application.Features.LanguageTechnologies.Dtos;
using Application.Features.LanguageTechnologies.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.LanguageTechnologies.Queries.GetListLanguageTechnology
{
    public class GetListLanguageTechnologyQuery:IRequest<LanguageTechnologyListModel>
    {
        public PageRequest PageRequest { get; set; }

        public class GetListLanguageTechnologyQueryHandler : IRequestHandler<GetListLanguageTechnologyQuery, LanguageTechnologyListModel>
        {
            private readonly IMapper _mapper;
            private readonly ILanguageTechnologyRepository _languageTechnologyRepository;

            public GetListLanguageTechnologyQueryHandler(IMapper mapper, ILanguageTechnologyRepository languageTechnologyRepository)
            {
                _mapper = mapper;
                _languageTechnologyRepository = languageTechnologyRepository;
            }

            public async Task<LanguageTechnologyListModel> Handle(GetListLanguageTechnologyQuery request, CancellationToken cancellationToken)
            {
                IPaginate<LanguageTechnology> technologies = await _languageTechnologyRepository.GetListAsync(include:
                                                m => m.Include(c => c.ProgrammingLanguage),
                                                index: request.PageRequest.Page,
                                                size: request.PageRequest.PageSize
                                                );

                LanguageTechnologyListModel mappedlanguage = _mapper.Map<LanguageTechnologyListModel>(technologies);
                return mappedlanguage;
            }
        }
    }
}
