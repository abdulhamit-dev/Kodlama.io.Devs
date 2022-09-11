using Application.Features.LanguageTechnologies.Dtos;
using Application.Features.LanguageTechnologies.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.LanguageTechnologies.Commands
{
    public class CreateLanguageTechnologyCommand:IRequest<CreatedLanguageTechnologyDto>
    {
        public string Name { get; set; }
        public int ProgrammingLanguageId { get; set; }
        public class CreateLanguageTechnologyCommandHandler:IRequestHandler<CreateLanguageTechnologyCommand, CreatedLanguageTechnologyDto>
        {
            private readonly IMapper _mapper;
            private readonly ILanguageTechnologyRepository _languageTechnologyRepository;
            private readonly LanguageTechnologyBusinessRule _languageTechnologyBusinessRule;

            public CreateLanguageTechnologyCommandHandler(IMapper mapper, ILanguageTechnologyRepository languageTechnologyRepository, LanguageTechnologyBusinessRule languageTechnologyBusinessRule)
            {
                _mapper = mapper;
                _languageTechnologyRepository = languageTechnologyRepository;
                _languageTechnologyBusinessRule = languageTechnologyBusinessRule;
            }

            public async Task<CreatedLanguageTechnologyDto> Handle(CreateLanguageTechnologyCommand request, CancellationToken cancellationToken)
            {
                await _languageTechnologyBusinessRule.LanguageTechnologyNameCanNotBeDuplicatedWhenInserted(request.Name, request.ProgrammingLanguageId);

                LanguageTechnology mappedTechnology = _mapper.Map<LanguageTechnology>(request);
                
                LanguageTechnology createdlanguageTechnology = await _languageTechnologyRepository.AddAsync(mappedTechnology);
                
                CreatedLanguageTechnologyDto createLanguageTechnologyDto = _mapper.Map<CreatedLanguageTechnologyDto>(createdlanguageTechnology);
                
                return createLanguageTechnologyDto;
            }
        }
    }
}
