using Application.Features.ProgramingLanguages.Dtos;
using Application.Features.ProgramingLanguages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgramingLanguages.Commands.CreateProgramingLanguage
{
    public class CreateProgrammingLanguageCommand : IRequest<CreatedProgrammingLanguageDto>
    {
        public string Name { get; set; }

        public class CreateProgrammingLanguageCommandHandler : IRequestHandler<CreateProgrammingLanguageCommand, CreatedProgrammingLanguageDto>
        {
            private readonly IProgrammingLangugageRepository _programmingLanguageRepository;
            private readonly IMapper _mapper;
            private readonly ProgrammingLanguageBusinessRule _programingLanguageBusinessRule;
            public CreateProgrammingLanguageCommandHandler(IProgrammingLangugageRepository programmingLanguageRepository, IMapper mapper, ProgrammingLanguageBusinessRule programingLanguageBusinessRule)
            {
                _programmingLanguageRepository = programmingLanguageRepository;
                _mapper = mapper;
                _programingLanguageBusinessRule = programingLanguageBusinessRule;
            }

            public async Task<CreatedProgrammingLanguageDto> Handle(CreateProgrammingLanguageCommand request, CancellationToken cancellationToken)
            {
                await _programingLanguageBusinessRule.ProgramingNameCanNotBeDuplicatedWhenInserted(request.Name);
                ProgrammingLanguage programingLanguages = _mapper.Map<ProgrammingLanguage>(request);
                ProgrammingLanguage createdProgramingLanguage = _programmingLanguageRepository.Add(programingLanguages);
                CreatedProgrammingLanguageDto createdProgrammingLanguageDto = _mapper.Map<CreatedProgrammingLanguageDto>(createdProgramingLanguage);

                return createdProgrammingLanguageDto;

            }

        }
    }
}
