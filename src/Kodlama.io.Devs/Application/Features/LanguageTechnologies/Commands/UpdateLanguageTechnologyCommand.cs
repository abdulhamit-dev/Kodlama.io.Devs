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
    public class UpdateLanguageTechnologyCommand:IRequest<UpdatedLanguageTechnologyDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProgrammingLanguageId { get; set; }

        public class UpdateLanguageTechnologyCommandhandler : IRequestHandler<UpdateLanguageTechnologyCommand, UpdatedLanguageTechnologyDto>
        {
            private readonly IMapper _mapper;
            private readonly ILanguageTechnologyRepository _languageTechnologyRepository;
            private readonly LanguageTechnologyBusinessRule _languageTechnologyBusinessRule;

            public UpdateLanguageTechnologyCommandhandler(IMapper mapper, ILanguageTechnologyRepository languageTechnologyRepository, LanguageTechnologyBusinessRule languageTechnologyBusinessRule)
            {
                _mapper = mapper;
                _languageTechnologyRepository = languageTechnologyRepository;
                _languageTechnologyBusinessRule = languageTechnologyBusinessRule;
            }

            public async Task<UpdatedLanguageTechnologyDto> Handle(UpdateLanguageTechnologyCommand request, CancellationToken cancellationToken)
            {
                await _languageTechnologyBusinessRule.LanguageTechnologyNameCanNotBeDuplicatedWhenInserted(request.Name, request.ProgrammingLanguageId);

                LanguageTechnology mappedlanguageTechnology = _mapper.Map<LanguageTechnology>(request);

                LanguageTechnology languageTechnology = await _languageTechnologyRepository.UpdateAsync(mappedlanguageTechnology);
                
                UpdatedLanguageTechnologyDto updatedLanguageTechnologyDto=_mapper.Map<UpdatedLanguageTechnologyDto>(languageTechnology);
                
                return updatedLanguageTechnologyDto;

            }
        }
    }
}
