using Application.Features.ProgrammingLanguages.Dtos;
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
    public class DeleteLanguageTechnologyCommand:IRequest<DeletedProgrammingLanguageDto>
    {
        public int Id { get; set; }
        public class DeleteLanguageTechnologyCommandHandler : IRequestHandler<DeleteLanguageTechnologyCommand, DeletedProgrammingLanguageDto>
        {
            private readonly IMapper _mapper;
            private readonly ILanguageTechnologyRepository _languageTechnologyRepository;

            public DeleteLanguageTechnologyCommandHandler(IMapper mapper, ILanguageTechnologyRepository languageTechnologyRepository)
            {
                _mapper = mapper;
                _languageTechnologyRepository = languageTechnologyRepository;
            }

            public async Task<DeletedProgrammingLanguageDto> Handle(DeleteLanguageTechnologyCommand request, CancellationToken cancellationToken)
            {
                LanguageTechnology mappedLang = _mapper.Map<LanguageTechnology>(request);
                LanguageTechnology languageTechnology = await _languageTechnologyRepository.DeleteAsync(mappedLang);
                DeletedProgrammingLanguageDto deletedProgrammingLanguageDto=_mapper.Map<DeletedProgrammingLanguageDto>(languageTechnology);
                return deletedProgrammingLanguageDto;
            }
        }
    }
}
